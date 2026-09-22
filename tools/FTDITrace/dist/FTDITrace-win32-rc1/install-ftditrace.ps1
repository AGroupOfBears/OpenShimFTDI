<#
.SYNOPSIS
Safely installs FTDITrace proxy into a TuneECU directory.

.DESCRIPTION
Injects the FTDITrace proxy DLL (FTD2XX.dll) into a target TuneECU directory
and sets up FTD2XX_REAL.dll from either:
  Scenario A: Existing local genuine FTD2XX.dll (backed up to FTD2XX_REAL.dll)
  Scenario B: System genuine 32-bit D2XX DLL (copied to FTD2XX_REAL.dll, leaving SysWOW64 untouched)

Creates an install-state manifest (FTDITrace.install.json) in the TuneECU directory.
Strictly protects genuine drivers: FTD2XX_REAL.dll is immutable and repeat-install is refused.

.PARAMETER TuneEcuDir
Path to the target TuneECU application directory. Defaults to:
C:\Users\xer0\Desktop\TuneECUv2.5.5

.PARAMETER ProxyDll
Path to the FTDITrace proxy FTD2XX.dll. Defaults to the proxy inside the release package.

.PARAMETER RealD2xxPath
Path to the genuine 32-bit FTDI D2XX DLL. Defaults to:
$env:WINDIR\SysWOW64\ftd2xx.dll

.EXAMPLE
.\install-ftditrace.ps1 -TuneEcuDir "C:\Users\xer0\Desktop\TuneECUv2.5.5"
#>

[CmdletBinding(SupportsShouldProcess = $true)]
param(
    [Parameter(Position = 0, Mandatory = $false)]
    [Alias("TuneECUDir")]
    [string]$TuneEcuDir = "C:\Users\xer0\Desktop\TuneECUv2.5.5",

    [Parameter(Position = 1, Mandatory = $false)]
    [string]$ProxyDll,

    [Parameter(Position = 2, Mandatory = $false)]
    [string]$RealD2xxPath = "$env:WINDIR\SysWOW64\ftd2xx.dll"
)

$ErrorActionPreference = "Stop"

$FTDITRACE_VERSION = "1.1.0"
$SOURCE_GIT_COMMIT = "6424f37b4df6b9270a46666881f670e758acb534"
$MANIFEST_SCHEMA_VER = "1.0.0"

function Get-FileHashString([string]$filePath) {
    if (Test-Path $filePath) {
        $h = Get-FileHash -Path $filePath -Algorithm SHA256
        return $h.Hash.ToLowerInvariant()
    }
    return $null
}

function Test-PE32Architecture([string]$filePath) {
    if (-not (Test-Path $filePath)) {
        return @{ Valid = $false; Error = "File not found: $filePath" }
    }
    $stream = $null
    $reader = $null
    try {
        $stream = [System.IO.File]::OpenRead($filePath)
        $reader = New-Object System.IO.BinaryReader($stream)
        
        # Check DOS header 'MZ' (0x5A4D)
        if ($stream.Length -lt 64) {
            return @{ Valid = $false; Error = "File too small to be a valid PE binary: $filePath" }
        }
        $mz = $reader.ReadUInt16()
        if ($mz -ne 0x5A4D) {
            return @{ Valid = $false; Error = "Missing DOS 'MZ' signature: $filePath" }
        }
        
        # Seek to e_lfanew at 0x3C
        $stream.Seek(0x3C, [System.IO.SeekOrigin]::Begin) | Out-Null
        $peOffset = $reader.ReadInt32()
        if ($peOffset -le 0 -or $peOffset -ge ($stream.Length - 64)) {
            return @{ Valid = $false; Error = "Invalid PE header offset: $peOffset" }
        }
        
        # Seek to PE signature
        $stream.Seek($peOffset, [System.IO.SeekOrigin]::Begin) | Out-Null
        $peSig = $reader.ReadUInt32()
        if ($peSig -ne 0x00004550) { # 'PE\0\0'
            return @{ Valid = $false; Error = "Missing 'PE\0\0' signature at offset $peOffset" }
        }
        
        # Machine type at peOffset + 4
        $machine = $reader.ReadUInt16()
        
        # Skip remaining FileHeader (16 bytes) to reach OptionalHeader at peOffset + 24
        $stream.Seek($peOffset + 24, [System.IO.SeekOrigin]::Begin) | Out-Null
        $optMagic = $reader.ReadUInt16()
        
        # Check 64-bit PE32+ rejection
        if ($machine -eq 0x8664 -or $optMagic -eq 0x020B) {
            return @{
                Valid = $false
                Is64Bit = $true
                Error = "64-bit PE32+ (x64) binary detected! TuneECU is a 32-bit application and requires a 32-bit (i386/PE32) DLL (e.g. from SysWOW64). Do NOT use C:\Windows\System32\ftd2xx.dll."
            }
        }
        
        # Check 32-bit i386 / PE32
        if ($machine -ne 0x014C -or $optMagic -ne 0x010B) {
            return @{
                Valid = $false
                Is64Bit = $false
                Error = ("Invalid architecture: Machine=0x{0:X4}, Magic=0x{1:X4}. Expected 32-bit i386 PE32 (0x014C / 0x010B)." -f $machine, $optMagic)
            }
        }
        
        return @{ Valid = $true; Machine = $machine; Magic = $optMagic; Is64Bit = $false }
    } catch {
        return @{ Valid = $false; Error = $_.Exception.Message }
    } finally {
        if ($reader) { $reader.Close() }
        if ($stream) { $stream.Close() }
    }
}

Write-Host "=================================================="
Write-Host " FTDITrace Production Proxy Installer"
Write-Host " Version: $FTDITRACE_VERSION"
Write-Host "=================================================="

# 1. Resolve TuneECUDir
if (-Not (Test-Path $TuneEcuDir)) {
    Write-Error "Target TuneECU directory does not exist: $TuneEcuDir"
    return
}
$targetDirResolved = (Resolve-Path $TuneEcuDir).Path
Write-Host "Target Directory : $targetDirResolved"

# 2. Resolve Proxy DLL
if ([string]::IsNullOrWhiteSpace($ProxyDll)) {
    $cand1 = Join-Path $PSScriptRoot "FTD2XX.dll"
    $cand2 = Join-Path $PSScriptRoot "..\FTD2XX.dll"
    if (Test-Path $cand1) {
        $ProxyDll = $cand1
    } elseif (Test-Path $cand2) {
        $ProxyDll = $cand2
    } else {
        Write-Error "Could not locate FTDITrace proxy FTD2XX.dll in package ($cand1 or $cand2). Specify -ProxyDll explicitly."
        return
    }
}
if (-Not (Test-Path $ProxyDll)) {
    Write-Error "Proxy DLL not found: $ProxyDll"
    return
}
$proxyResolved = (Resolve-Path $ProxyDll).Path
$proxyHash = Get-FileHashString $proxyResolved
$proxySize = (Get-Item $proxyResolved).Length

Write-Host "Proxy DLL Source : $proxyResolved"
Write-Host "Proxy Size (B)   : $proxySize"
Write-Host "Proxy SHA-256    : $proxyHash"

# Validate Proxy Architecture
$proxyArch = Test-PE32Architecture $proxyResolved
if (-not $proxyArch.Valid) {
    Write-Error "Proxy DLL validation failed: $($proxyArch.Error)"
    return
}
Write-Host "Proxy Arch Check : PASS (PE32 / i386 0x014c)"
Write-Host "--------------------------------------------------"

$targetFtd2xx   = Join-Path $targetDirResolved "FTD2XX.dll"
$targetReal     = Join-Path $targetDirResolved "FTD2XX_REAL.dll"
$targetManifest = Join-Path $targetDirResolved "FTDITrace.install.json"

$ftd2xxExists   = Test-Path $targetFtd2xx
$realExists     = Test-Path $targetReal
$manifestExists = Test-Path $targetManifest

# IMMUTABILITY & REPEAT-INSTALL CHECK
if ($realExists -or $manifestExists) {
    Write-Host ""
    Write-Host "PRE-INSTALL SAFETY REFUSAL:" -ForegroundColor Yellow
    if ($realExists)     { Write-Host "  - FTD2XX_REAL.dll already exists in $targetDirResolved" }
    if ($manifestExists) { Write-Host "  - FTDITrace.install.json already exists in $targetDirResolved" }
    Write-Host ""
    Write-Error "REFUSAL: FTDITrace appears already installed or an unmanaged backup exists. To protect the genuine FTDI driver and test state, existing FTD2XX_REAL.dll is immutable and will NEVER be overwritten. Run uninstall-ftditrace.ps1 first if you wish to uninstall or reinstall."
    return
}

# SCENARIO DETERMINATION
if ($ftd2xxExists) {
    # ==================================================
    # SCENARIO A: Local genuine FTD2XX.dll already exists
    # ==================================================
    Write-Host "Detected: SCENARIO A (TuneECU folder contains local FTD2XX.dll)"
    $origHash = Get-FileHashString $targetFtd2xx
    Write-Host "  Original Local DLL SHA-256: $origHash"
    
    $origArch = Test-PE32Architecture $targetFtd2xx
    if (-not $origArch.Valid) {
        Write-Error "Existing local FTD2XX.dll validation failed: $($origArch.Error)"
        return
    }
    Write-Host "  Original Local DLL Arch    : PASS (PE32 / i386)"
    
    Write-Host ""
    Write-Host "Planned actions:"
    Write-Host "  1. Back up: $targetFtd2xx -> $targetReal"
    Write-Host "  2. Install: $proxyResolved -> $targetFtd2xx"
    Write-Host "  3. Write  : $targetManifest"
    
    if ($PSCmdlet.ShouldProcess($targetDirResolved, "Install FTDITrace proxy (Scenario A: backup local DLL to FTD2XX_REAL.dll)")) {
        # Safe Move: since $realExists is false, this creates FTD2XX_REAL.dll without overwriting
        Move-Item -Path $targetFtd2xx -Destination $targetReal -ErrorAction Stop
        Write-Host "Preserved local genuine DLL as FTD2XX_REAL.dll"
        
        Copy-Item -Path $proxyResolved -Destination $targetFtd2xx -ErrorAction Stop
        Write-Host "Installed FTDITrace proxy as FTD2XX.dll"
        
        $installedRealHash = Get-FileHashString $targetReal
        $installedProxyHash = Get-FileHashString $targetFtd2xx
        
        if ($installedRealHash -ne $origHash -or $installedProxyHash -ne $proxyHash) {
            Write-Error "FATAL: Hash mismatch after file copy! Aborting."
            return
        }
        
        $timestamp = [DateTime]::UtcNow.ToString("o")
        $manifestObj = [ordered]@{
            schema_version               = $MANIFEST_SCHEMA_VER
            ftditrace_version            = $FTDITRACE_VERSION
            installation_timestamp       = $timestamp
            tuneecu_directory            = $targetDirResolved
            original_local_d2xx_present  = $true
            original_local_d2xx_sha256   = $origHash
            real_d2xx_source_path        = "$targetDirResolved\FTD2XX.dll (local backup)"
            real_d2xx_sha256             = $origHash
            ftd2xx_real_sha256           = $installedRealHash
            proxy_sha256                 = $installedProxyHash
            proxy_file_size              = $proxySize
            source_git_commit            = $SOURCE_GIT_COMMIT
            architecture                 = "win32-x86"
        }
        
        $manifestJson = ConvertTo-Json -InputObject $manifestObj -Depth 4
        [System.IO.File]::WriteAllText($targetManifest, $manifestJson)
        Write-Host "Created installation manifest: FTDITrace.install.json"
        Write-Host ""
        Write-Host "SUCCESS: Scenario A installation completed safely and verified." -ForegroundColor Green
    }
} else {
    # ==================================================
    # SCENARIO B: No local FTD2XX.dll (Relies on SysWOW64)
    # The actual current Windows 11 reference baseline!
    # ==================================================
    Write-Host "Detected: SCENARIO B (TuneECU folder has NO local FTD2XX.dll; relies on SysWOW64)"
    
    if (-not (Test-Path $RealD2xxPath)) {
        Write-Error "Genuine 32-bit D2XX DLL not found at: $RealD2xxPath. TuneECU requires genuine FTDI driver installed in SysWOW64 or specified via -RealD2xxPath."
        return
    }
    $realResolved = (Resolve-Path $RealD2xxPath).Path
    Write-Host "Genuine D2XX Source : $realResolved"
    
    # Architecture check for genuine backend (reject 64-bit System32!)
    $realArch = Test-PE32Architecture $realResolved
    if (-not $realArch.Valid) {
        Write-Error "Genuine D2XX DLL validation failed: $($realArch.Error)"
        return
    }
    Write-Host "Genuine D2XX Arch   : PASS (PE32 / i386)"
    
    $genuineHash = Get-FileHashString $realResolved
    Write-Host "Genuine D2XX SHA-256: $genuineHash"
    
    Write-Host ""
    Write-Host "Planned actions:"
    Write-Host "  1. Copy genuine DLL: $realResolved -> $targetReal"
    Write-Host "     (SysWOW64 is NOT moved or altered)"
    Write-Host "  2. Install proxy   : $proxyResolved -> $targetFtd2xx"
    Write-Host "  3. Write manifest  : $targetManifest"
    
    if ($PSCmdlet.ShouldProcess($targetDirResolved, "Install FTDITrace proxy (Scenario B: copy SysWOW64 genuine DLL to FTD2XX_REAL.dll)")) {
        Copy-Item -Path $realResolved -Destination $targetReal -ErrorAction Stop
        Write-Host "Copied genuine 32-bit DLL to FTD2XX_REAL.dll"
        
        Copy-Item -Path $proxyResolved -Destination $targetFtd2xx -ErrorAction Stop
        Write-Host "Installed FTDITrace proxy as FTD2XX.dll"
        
        $installedRealHash = Get-FileHashString $targetReal
        $installedProxyHash = Get-FileHashString $targetFtd2xx
        
        if ($installedRealHash -ne $genuineHash -or $installedProxyHash -ne $proxyHash) {
            Write-Error "FATAL: Hash mismatch after file copy! Aborting."
            return
        }
        
        $timestamp = [DateTime]::UtcNow.ToString("o")
        $manifestObj = [ordered]@{
            schema_version               = $MANIFEST_SCHEMA_VER
            ftditrace_version            = $FTDITRACE_VERSION
            installation_timestamp       = $timestamp
            tuneecu_directory            = $targetDirResolved
            original_local_d2xx_present  = $false
            original_local_d2xx_sha256   = $null
            real_d2xx_source_path        = $realResolved
            real_d2xx_sha256             = $genuineHash
            ftd2xx_real_sha256           = $installedRealHash
            proxy_sha256                 = $installedProxyHash
            proxy_file_size              = $proxySize
            source_git_commit            = $SOURCE_GIT_COMMIT
            architecture                 = "win32-x86"
        }
        
        $manifestJson = ConvertTo-Json -InputObject $manifestObj -Depth 4
        [System.IO.File]::WriteAllText($targetManifest, $manifestJson)
        Write-Host "Created installation manifest: FTDITrace.install.json"
        Write-Host ""
        Write-Host "SUCCESS: Scenario B installation completed safely and verified." -ForegroundColor Green
    }
}

Write-Host "=================================================="
