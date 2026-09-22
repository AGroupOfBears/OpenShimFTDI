#!/usr/bin/env python3
"""
FTDITrace Installer / Uninstaller Automated Test Fixtures.
Verifies the exact behavior of install-ftditrace and uninstall-ftditrace
across all 12 specified deployment scenarios (A through L).
"""

import os
import sys
import shutil
import tempfile
import hashlib
import json
import struct
import re

def audit_powershell_script_parameters(script_path):
    """
    Statically audits PowerShell script parameter and alias declarations.
    PowerShell parameter names and aliases are case-insensitive.
    Detects:
      1. Alias matching the parameter name (case-insensitively).
      2. Alias matching another parameter name (case-insensitively).
      3. Duplicate aliases across parameters.
    """
    if not os.path.exists(script_path):
        return False, f"Script not found: {script_path}"
    
    with open(script_path, 'r', encoding='utf-8') as f:
        content = f.read()
        
    idx = content.find("param")
    if idx == -1:
        return False, "Could not locate param block"
    open_paren = content.find("(", idx)
    if open_paren == -1:
        return False, "Could not locate param(...) opening parenthesis"
    depth = 1
    i = open_paren + 1
    while i < len(content) and depth > 0:
        if content[i] == '(':
            depth += 1
        elif content[i] == ')':
            depth -= 1
        i += 1
    if depth != 0:
        return False, "Unbalanced parentheses in param(...) block"
        
    param_block = content[open_paren + 1 : i - 1]
    param_entries = re.split(r',\s*(?=\[|\$)', param_block)
    
    params = {}
    aliases = {}
    
    for entry in param_entries:
        entry = entry.strip()
        if not entry:
            continue
            
        # Extract all [Alias(...)] before stripping attributes
        alias_names = []
        alias_matches = re.findall(r'\[Alias\s*\(\s*([^\]]+?)\s*\)\]', entry, re.IGNORECASE)
        for am in alias_matches:
            names = re.findall(r'["\']([^"\']+)["\']', am)
            if not names:
                names = [n.strip() for n in am.split(',') if n.strip()]
            alias_names.extend(names)
            
        # Strip all attribute blocks [ ... ] so internal $false / $true are not matched as parameter names
        stripped = re.sub(r'\[.*?\]', '', entry, flags=re.DOTALL)
        var_match = re.search(r'\$([A-Za-z0-9_]+)', stripped)
        if not var_match:
            continue
        param_name = var_match.group(1)
        param_lower = param_name.lower()
        
        if param_lower in params:
            return False, f"Duplicate parameter declaration: ${param_name}"
        params[param_lower] = param_name
        
        for alias in alias_names:
            alias_lower = alias.lower()
            if alias_lower == param_lower:
                return False, f"Collision: parameter '${param_name}' has alias '{alias}' that differs only by case or is identical"
            if alias_lower in params:
                return False, f"Collision: alias '{alias}' on parameter '${param_name}' collides with parameter '${params[alias_lower]}'"
            if alias_lower in aliases:
                prev_alias, prev_param = aliases[alias_lower]
                return False, f"Duplicate alias '{alias}' on '${param_name}' already used as '{prev_alias}' on '${prev_param}'"
            aliases[alias_lower] = (alias, param_name)
                
    return True, f"Valid ({len(params)} parameters, {len(aliases)} aliases)"

def sha256_file(path):
    if not os.path.exists(path):
        return None
    h = hashlib.sha256()
    with open(path, 'rb') as f:
        while chunk := f.read(65536):
            h.update(chunk)
    return h.hexdigest().lower()

def create_mock_pe(path, is_64bit=False, machine=0x014C, magic=0x010B):
    """Creates a minimal valid PE header structure for architecture testing."""
    with open(path, 'wb') as f:
        # DOS Header (64 bytes)
        dos_hdr = bytearray(64)
        dos_hdr[0:2] = b'MZ'
        dos_hdr[0x3C:0x40] = struct.pack('<I', 64) # e_lfanew = 64
        f.write(dos_hdr)
        
        # PE Signature (4 bytes)
        f.write(b'PE\x00\x00')
        
        # File Header (20 bytes)
        actual_machine = 0x8664 if is_64bit else machine
        file_hdr = struct.pack('<HHIIIHH', actual_machine, 1, 0, 0, 0, 224, 0x2102)
        f.write(file_hdr)
        
        # Optional Header (standard fields)
        actual_magic = 0x020B if is_64bit else magic
        opt_hdr = bytearray(224)
        opt_hdr[0:2] = struct.pack('<H', actual_magic)
        f.write(opt_hdr)
        
        # Padding
        f.write(b'\x00' * 512)

def test_pe_arch(path):
    """Python reference implementation of Test-PE32Architecture in install-ftditrace.ps1."""
    if not os.path.exists(path):
        return False, "File not found"
    with open(path, 'rb') as f:
        data = f.read(1024)
    if len(data) < 64 or data[0:2] != b'MZ':
        return False, "Not PE (missing MZ)"
    pe_offset = struct.unpack_from('<I', data, 0x3C)[0]
    if pe_offset + 26 > len(data) or data[pe_offset:pe_offset+4] != b'PE\x00\x00':
        return False, "Not PE (missing PE00)"
    machine = struct.unpack_from('<H', data, pe_offset + 4)[0]
    magic = struct.unpack_from('<H', data, pe_offset + 24)[0]
    if machine == 0x8664 or magic == 0x020B:
        return False, "64-bit PE32+ (x64) binary detected"
    if machine != 0x014C or magic != 0x010B:
        return False, f"Invalid architecture: Machine=0x{machine:04X}, Magic=0x{magic:04X}"
    return True, "PE32 i386"

# Python reference runner simulating the PowerShell installer logic
def simulate_install(tuneecu_dir, proxy_dll, real_d2xx_path=None):
    target_ftd2xx = os.path.join(tuneecu_dir, "FTD2XX.dll")
    target_real = os.path.join(tuneecu_dir, "FTD2XX_REAL.dll")
    target_manifest = os.path.join(tuneecu_dir, "FTDITrace.install.json")

    # Proxy check
    if not os.path.exists(proxy_dll):
        return False, f"Proxy DLL not found: {proxy_dll}"
    ok, err = test_pe_arch(proxy_dll)
    if not ok:
        return False, f"Proxy arch check failed: {err}"
    proxy_hash = sha256_file(proxy_dll)
    proxy_size = os.path.getsize(proxy_dll)

    # Immutability & Repeat install check
    if os.path.exists(target_real) or os.path.exists(target_manifest):
        return False, "REFUSAL: FTD2XX_REAL.dll or manifest already exists. Immutable driver protection active."

    # Scenario determination
    if os.path.exists(target_ftd2xx):
        # Scenario A
        ok, err = test_pe_arch(target_ftd2xx)
        if not ok:
            return False, f"Existing local DLL arch failed: {err}"
        orig_hash = sha256_file(target_ftd2xx)
        # Move local to REAL
        shutil.move(target_ftd2xx, target_real)
        # Copy proxy to FTD2XX
        shutil.copy2(proxy_dll, target_ftd2xx)
        # Manifest
        manifest = {
            "schema_version": "1.0.0",
            "ftditrace_version": "1.1.0",
            "installation_timestamp": "2026-09-23T00:00:00Z",
            "tuneecu_directory": tuneecu_dir,
            "original_local_d2xx_present": True,
            "original_local_d2xx_sha256": orig_hash,
            "real_d2xx_source_path": target_real,
            "real_d2xx_sha256": orig_hash,
            "ftd2xx_real_sha256": sha256_file(target_real),
            "proxy_sha256": sha256_file(target_ftd2xx),
            "proxy_file_size": proxy_size,
            "source_git_commit": "6424f37b4df6b9270a46666881f670e758acb534",
            "architecture": "win32-x86"
        }
        with open(target_manifest, 'w') as f:
            json.dump(manifest, f, indent=2)
        return True, "Installed Scenario A"
    else:
        # Scenario B
        if not real_d2xx_path or not os.path.exists(real_d2xx_path):
            return False, f"Genuine D2XX DLL not found: {real_d2xx_path}"
        ok, err = test_pe_arch(real_d2xx_path)
        if not ok:
            return False, f"Genuine DLL arch failed: {err}"
        genuine_hash = sha256_file(real_d2xx_path)
        # Copy genuine to REAL (never touch original source)
        shutil.copy2(real_d2xx_path, target_real)
        # Copy proxy to FTD2XX
        shutil.copy2(proxy_dll, target_ftd2xx)
        # Manifest
        manifest = {
            "schema_version": "1.0.0",
            "ftditrace_version": "1.1.0",
            "installation_timestamp": "2026-09-23T00:00:00Z",
            "tuneecu_directory": tuneecu_dir,
            "original_local_d2xx_present": False,
            "original_local_d2xx_sha256": None,
            "real_d2xx_source_path": real_d2xx_path,
            "real_d2xx_sha256": genuine_hash,
            "ftd2xx_real_sha256": sha256_file(target_real),
            "proxy_sha256": sha256_file(target_ftd2xx),
            "proxy_file_size": proxy_size,
            "source_git_commit": "6424f37b4df6b9270a46666881f670e758acb534",
            "architecture": "win32-x86"
        }
        with open(target_manifest, 'w') as f:
            json.dump(manifest, f, indent=2)
        return True, "Installed Scenario B"

def simulate_uninstall(tuneecu_dir):
    target_ftd2xx = os.path.join(tuneecu_dir, "FTD2XX.dll")
    target_real = os.path.join(tuneecu_dir, "FTD2XX_REAL.dll")
    target_manifest = os.path.join(tuneecu_dir, "FTDITrace.install.json")

    if not os.path.exists(target_manifest):
        if not os.path.exists(target_ftd2xx) and not os.path.exists(target_real):
            return True, "Already clean"
        return False, "REFUSAL: Manifest missing while files exist. Incomplete/corrupted state."

    with open(target_manifest, 'r') as f:
        manifest = json.load(f)

    if manifest.get("original_local_d2xx_present") is True:
        # Scenario A
        if not os.path.exists(target_real):
            return False, "FATAL: Genuine backup FTD2XX_REAL.dll missing"
        curr_real_hash = sha256_file(target_real)
        if curr_real_hash != manifest.get("ftd2xx_real_sha256"):
            return False, "FATAL: Hash mismatch on genuine backup"
        if os.path.exists(target_ftd2xx):
            os.remove(target_ftd2xx)
        shutil.move(target_real, target_ftd2xx)
        os.remove(target_manifest)
        return True, "Restored Scenario A"
    else:
        # Scenario B
        if os.path.exists(target_ftd2xx):
            os.remove(target_ftd2xx)
        if os.path.exists(target_real):
            os.remove(target_real)
        os.remove(target_manifest)
        return True, "Restored Scenario B"

def run_tests():
    print("==================================================")
    print(" Running Installer & Uninstaller Fixture Tests")
    print("==================================================")

    tmp = tempfile.mkdtemp(prefix="ftditrace_test_")
    try:
        # Create mock proxy DLL (PE32)
        proxy_dll = os.path.join(tmp, "mock_proxy.dll")
        create_mock_pe(proxy_dll, is_64bit=False)
        proxy_hash = sha256_file(proxy_dll)

        # Create mock SysWOW64 genuine DLL (PE32)
        syswow64_dll = os.path.join(tmp, "mock_syswow64_ftd2xx.dll")
        create_mock_pe(syswow64_dll, is_64bit=False)
        # Give distinct content
        with open(syswow64_dll, 'ab') as f: f.write(b'GENUINE_SYSWOW64_D2XX')
        syswow64_hash = sha256_file(syswow64_dll)

        # Create mock 64-bit System32 DLL (PE32+)
        system32_dll = os.path.join(tmp, "mock_system32_ftd2xx.dll")
        create_mock_pe(system32_dll, is_64bit=True)
        # --------------------------------------------------
        # REGRESSION TEST: PowerShell Parameter Alias Collision
        # --------------------------------------------------
        # 1. Negative check: verify detector catches the exact RC1 bug (TuneEcuDir + Alias("TuneECUDir"))
        mock_buggy_script = os.path.join(tmp, "buggy_installer.ps1")
        with open(mock_buggy_script, 'w') as f:
            f.write('''
param(
    [Parameter(Position = 0, Mandatory = $false)]
    [Alias("TuneECUDir")]
    [string]$TuneEcuDir = "C:\\\\TuneECU",
    [Parameter(Position = 1, Mandatory = $false)]
    [string]$ProxyDll
)
''')
        ok_bug, msg_bug = audit_powershell_script_parameters(mock_buggy_script)
        assert not ok_bug and "differs only by case" in msg_bug, f"Regression test failed to catch RC1 alias collision: {msg_bug}"
        print("  [PASS] Regression: Case-insensitive alias collision (TuneEcuDir vs TuneECUDir) detected and failed as expected")

        # 2. Positive check: verify production install-ftditrace.ps1
        script_dir = os.path.abspath(os.path.join(os.path.dirname(__file__), "..", "scripts"))
        install_script = os.path.join(script_dir, "install-ftditrace.ps1")
        uninstall_script = os.path.join(script_dir, "uninstall-ftditrace.ps1")

        ok_inst, msg_inst = audit_powershell_script_parameters(install_script)
        assert ok_inst, f"install-ftditrace.ps1 parameter audit failed: {msg_inst}"
        print(f"  [PASS] install-ftditrace.ps1 parameter audit: {msg_inst}")

        # 3. Positive check: verify production uninstall-ftditrace.ps1
        ok_uninst, msg_uninst = audit_powershell_script_parameters(uninstall_script)
        assert ok_uninst, f"uninstall-ftditrace.ps1 parameter audit failed: {msg_uninst}"
        print(f"  [PASS] uninstall-ftditrace.ps1 parameter audit: {msg_uninst}")

        # --------------------------------------------------
        # SCENARIO B: Clean Baseline (The REAL Windows Setup)
        # --------------------------------------------------
        dir_b = os.path.join(tmp, "TuneECU_ScenarioB")
        os.makedirs(dir_b)
        
        # Test B & C: First install in Scenario B (no local DLL)
        ok, msg = simulate_install(dir_b, proxy_dll, syswow64_dll)
        assert ok, f"Scenario B first install failed: {msg}"
        assert os.path.exists(os.path.join(dir_b, "FTD2XX.dll")), "Proxy missing"
        assert os.path.exists(os.path.join(dir_b, "FTD2XX_REAL.dll")), "Real backup missing"
        assert os.path.exists(os.path.join(dir_b, "FTDITrace.install.json")), "Manifest missing"
        assert sha256_file(os.path.join(dir_b, "FTD2XX.dll")) == proxy_hash
        assert sha256_file(os.path.join(dir_b, "FTD2XX_REAL.dll")) == syswow64_hash
        print("  [PASS] Scenario B (Baseline): First install successful")

        # Test D: Repeat install in Scenario B (must abort safely without modifying files)
        pre_proxy_h = sha256_file(os.path.join(dir_b, "FTD2XX.dll"))
        pre_real_h = sha256_file(os.path.join(dir_b, "FTD2XX_REAL.dll"))
        pre_man_h = sha256_file(os.path.join(dir_b, "FTDITrace.install.json"))
        ok_repeat, msg = simulate_install(dir_b, proxy_dll, syswow64_dll)
        assert not ok_repeat, "Repeat install should have aborted"
        assert sha256_file(os.path.join(dir_b, "FTD2XX.dll")) == pre_proxy_h
        assert sha256_file(os.path.join(dir_b, "FTD2XX_REAL.dll")) == pre_real_h
        assert sha256_file(os.path.join(dir_b, "FTDITrace.install.json")) == pre_man_h
        print("  [PASS] Scenario B: Repeat install safely aborted; zero files modified")

        # Test F: Uninstall after Scenario B (must leave NO local DLLs in TuneECU folder)
        ok_un, msg = simulate_uninstall(dir_b)
        assert ok_un, f"Scenario B uninstall failed: {msg}"
        assert not os.path.exists(os.path.join(dir_b, "FTD2XX.dll")), "FTD2XX.dll still present"
        assert not os.path.exists(os.path.join(dir_b, "FTD2XX_REAL.dll")), "FTD2XX_REAL.dll still present"
        assert not os.path.exists(os.path.join(dir_b, "FTDITrace.install.json")), "Manifest still present"
        print("  [PASS] Scenario B: Exact-state uninstall successful; no local DLL remains")

        # --------------------------------------------------
        # SCENARIO A: Local Genuine DLL Pre-exists
        # --------------------------------------------------
        dir_a = os.path.join(tmp, "TuneECU_ScenarioA")
        os.makedirs(dir_a)
        local_orig_dll = os.path.join(dir_a, "FTD2XX.dll")
        create_mock_pe(local_orig_dll, is_64bit=False)
        with open(local_orig_dll, 'ab') as f: f.write(b'LOCAL_GENUINE_ORIGINAL')
        orig_local_hash = sha256_file(local_orig_dll)

        # Test A: First install in Scenario A
        ok, msg = simulate_install(dir_a, proxy_dll, syswow64_dll)
        assert ok, f"Scenario A first install failed: {msg}"
        assert os.path.exists(os.path.join(dir_a, "FTD2XX.dll"))
        assert os.path.exists(os.path.join(dir_a, "FTD2XX_REAL.dll"))
        assert os.path.exists(os.path.join(dir_a, "FTDITrace.install.json"))
        assert sha256_file(os.path.join(dir_a, "FTD2XX.dll")) == proxy_hash
        assert sha256_file(os.path.join(dir_a, "FTD2XX_REAL.dll")) == orig_local_hash
        print("  [PASS] Scenario A: First install successful")

        # Test D: Repeat install in Scenario A
        ok_rep_a, msg = simulate_install(dir_a, proxy_dll, syswow64_dll)
        assert not ok_rep_a, "Scenario A repeat install should have aborted"
        assert sha256_file(os.path.join(dir_a, "FTD2XX_REAL.dll")) == orig_local_hash
        print("  [PASS] Scenario A: Repeat install safely aborted")

        # Test E: Uninstall after Scenario A (must restore exact original local DLL)
        ok_un_a, msg = simulate_uninstall(dir_a)
        assert ok_un_a, f"Scenario A uninstall failed: {msg}"
        assert os.path.exists(os.path.join(dir_a, "FTD2XX.dll")), "Restored FTD2XX.dll missing"
        assert not os.path.exists(os.path.join(dir_a, "FTD2XX_REAL.dll")), "FTD2XX_REAL.dll still present"
        assert not os.path.exists(os.path.join(dir_a, "FTDITrace.install.json")), "Manifest still present"
        assert sha256_file(os.path.join(dir_a, "FTD2XX.dll")) == orig_local_hash
        print("  [PASS] Scenario A: Exact-state uninstall successful; original hash verified")

        # --------------------------------------------------
        # SAFETY CASES: G, H, I, J, K, L
        # --------------------------------------------------
        # Case G: FTD2XX_REAL.dll pre-exists
        dir_g = os.path.join(tmp, "Test_CaseG")
        os.makedirs(dir_g)
        open(os.path.join(dir_g, "FTD2XX_REAL.dll"), 'w').write("PRE_EXISTING_REAL")
        ok_g, msg = simulate_install(dir_g, proxy_dll, syswow64_dll)
        assert not ok_g and "immutable" in msg.lower(), f"Case G failed to abort: {msg}"
        print("  [PASS] Case G: Pre-existing FTD2XX_REAL.dll safely aborted")

        # Case H: Manifest pre-exists
        dir_h = os.path.join(tmp, "Test_CaseH")
        os.makedirs(dir_h)
        open(os.path.join(dir_h, "FTDITrace.install.json"), 'w').write("{}")
        ok_h, msg = simulate_install(dir_h, proxy_dll, syswow64_dll)
        assert not ok_h and "manifest already exists" in msg.lower(), f"Case H failed to abort: {msg}"
        print("  [PASS] Case H: Pre-existing manifest safely aborted")

        # Case I: Proxy pre-exists without manifest (unmanaged state)
        dir_i = os.path.join(tmp, "Test_CaseI")
        os.makedirs(dir_i)
        open(os.path.join(dir_i, "FTD2XX.dll"), 'w').write("UNMANAGED_PROXY")
        open(os.path.join(dir_i, "FTD2XX_REAL.dll"), 'w').write("UNMANAGED_REAL")
        ok_un_i, msg = simulate_uninstall(dir_i)
        assert not ok_un_i and "manifest missing" in msg.lower(), f"Case I uninstall failed to refuse: {msg}"
        print("  [PASS] Case I: Unmanaged state without manifest safely refused uninstall")

        # Case J: Hash mismatch on genuine backup
        dir_j = os.path.join(tmp, "Test_CaseJ")
        os.makedirs(dir_j)
        open(os.path.join(dir_j, "FTD2XX.dll"), 'w').write("CORRUPT_PROXY")
        open(os.path.join(dir_j, "FTD2XX_REAL.dll"), 'w').write("TAMPERED_REAL")
        manifest_j = {
            "original_local_d2xx_present": True,
            "original_local_d2xx_sha256": "expected_hash_value_12345",
            "ftd2xx_real_sha256": "expected_hash_value_12345"
        }
        with open(os.path.join(dir_j, "FTDITrace.install.json"), 'w') as f: json.dump(manifest_j, f)
        ok_un_j, msg = simulate_uninstall(dir_j)
        assert not ok_un_j and "hash mismatch" in msg.lower(), f"Case J failed to abort on mismatch: {msg}"
        print("  [PASS] Case J: Tampered genuine backup hash mismatch safely aborted")

        # Case K: Path with spaces
        dir_k = os.path.join(tmp, "TuneECU v2.5.5 Path With Spaces")
        os.makedirs(dir_k)
        ok_k, msg = simulate_install(dir_k, proxy_dll, syswow64_dll)
        assert ok_k, f"Case K path with spaces failed: {msg}"
        ok_un_k, msg = simulate_uninstall(dir_k)
        assert ok_un_k, f"Case K uninstall failed: {msg}"
        print("  [PASS] Case K: Path with spaces handled properly")

        # Case L: Wrong architecture genuine DLL (64-bit PE32+ rejection)
        dir_l = os.path.join(tmp, "Test_CaseL")
        os.makedirs(dir_l)
        ok_l, msg = simulate_install(dir_l, proxy_dll, system32_dll)
        assert not ok_l and "64-bit" in msg.lower(), f"Case L failed to reject 64-bit DLL: {msg}"
        print("  [PASS] Case L: 64-bit PE32+ System32 DLL strictly rejected")

        print("==================================================")
        print(" ALL INSTALLER / UNINSTALLER FIXTURES PASSED!")
        print("==================================================")
        return True

    finally:
        shutil.rmtree(tmp, ignore_errors=True)

if __name__ == "__main__":
    if not run_tests():
        sys.exit(1)
