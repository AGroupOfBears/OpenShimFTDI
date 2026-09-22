<#
.SYNOPSIS
Safely uninstalls FTDITrace and restores exact original TuneECU baseline.

.DESCRIPTION
Reads FTDITrace.install.json to determine the original pre-installation state:
  Scenario A: Restores genuine FTD2XX_REAL.dll back to FTD2XX.dll and verifies hash.
  Scenario B: Removes both FTD2XX.dll and FTD2XX_REAL.dll, leaving NO local D2XX DLL,
              so TuneECU cleanly resumes resolving C:\Windows\SysWOW64\ftd2xx.dll.

Removes FTDITrace.install.json upon successful restoration.
Strictly refuses to touch system folders (SysWOW64, System32) or modify unmanaged directories.

.PARAMETER TuneEcuDir
Path to the target TuneECU application directory. Defaults to:
C:\Users\xer0\Desktop\TuneECUv2.5.5

.EXAMPLE
.\uninstall-ftditrace.ps1 -TuneEcuDir "C:\Users\xer0\Desktop\TuneECUv2.5.5"
#>

[CmdletBinding(SupportsShouldProcess = $true)]
param(
    [Parameter(Position = 0, Mandatory = $false)]
    [string]$TuneEcuDir = "C:\Users\xer0\Desktop\TuneECUv2.5.5"
)

$ErrorActionPreference = "Stop"

function Get-FileHashString([string]$filePath) {
    if (Test-Path $filePath) {
        $h = Get-FileHash -Path $filePath -Algorithm SHA256
        return $h.Hash.ToLowerInvariant()
    }
    return $null
}

Write-Host "=================================================="
Write-Host " FTDITrace Exact-State Uninstaller"
Write-Host "=================================================="

if (-Not (Test-Path $TuneEcuDir)) {
    Write-Error "Target TuneECU directory does not exist: $TuneEcuDir"
    return
}
$targetDirResolved = (Resolve-Path $TuneEcuDir).Path
Write-Host "Target Directory : $targetDirResolved"

$targetFtd2xx   = Join-Path $targetDirResolved "FTD2XX.dll"
$targetReal     = Join-Path $targetDirResolved "FTD2XX_REAL.dll"
$targetManifest = Join-Path $targetDirResolved "FTDITrace.install.json"

$ftd2xxExists   = Test-Path $targetFtd2xx
$realExists     = Test-Path $targetReal
$manifestExists = Test-Path $targetManifest

# 1. Check for Missing Manifest
if (-not $manifestExists) {
    if (-not $ftd2xxExists -and -not $realExists) {
        Write-Host "Clean State: Neither FTD2XX.dll, FTD2XX_REAL.dll, nor manifest exists in target directory."
        Write-Host "TuneECU is in clean baseline state. No uninstallation needed." -ForegroundColor Green
        return
    }
    
    Write-Host ""
    Write-Host "SAFETY REFUSAL: Missing Installation Manifest!" -ForegroundColor Yellow
    if ($ftd2xxExists) { Write-Host "  - Local FTD2XX.dll is present" }
    if ($realExists)   { Write-Host "  - Local FTD2XX_REAL.dll is present" }
    Write-Host ""
    Write-Error "REFUSAL: FTDITrace.install.json is missing. The uninstaller refuses to guess whether this installation was Scenario A (where genuine DLL must be restored) or Scenario B (where local DLLs must be deleted to use SysWOW64). Please inspect the folder and restore files manually."
    return
}

# 2. Parse and Validate Manifest
Write-Host "Found installation manifest: $targetManifest"
try {
    $manifestContent = [System.IO.File]::ReadAllText($targetManifest)
    $manifest = ConvertFrom-Json -InputObject $manifestContent
} catch {
    Write-Error "FATAL: Failed to parse installation manifest: $($_.Exception.Message)"
    return
}

Write-Host "  Installed Version : $($manifest.ftditrace_version)"
Write-Host "  Install Timestamp : $($manifest.installation_timestamp)"
Write-Host "  Scenario Mode     : $(if ($manifest.original_local_d2xx_present) { 'Scenario A (Original Local DLL)' } else { 'Scenario B (SysWOW64 Baseline)' })"
Write-Host "--------------------------------------------------"

if ($manifest.original_local_d2xx_present -eq $true) {
    # ==================================================
    # RESTORE SCENARIO A
    # Original state: local genuine FTD2XX.dll existed
    # ==================================================
    Write-Host "Executing Uninstall for SCENARIO A:"
    Write-Host "  Original genuine DLL must be restored to: FTD2XX.dll"
    
    if (-not $realExists) {
        Write-Error "FATAL: Genuine backup FTD2XX_REAL.dll not found in $targetDirResolved! Cannot restore genuine DLL. Manifest recorded original hash: $($manifest.original_local_d2xx_sha256)"
        return
    }
    
    $currentRealHash = Get-FileHashString $targetReal
    if ($currentRealHash -ne $manifest.ftd2xx_real_sha256) {
        Write-Error "FATAL: Genuine backup FTD2XX_REAL.dll hash ($currentRealHash) does not match recorded manifest hash ($($manifest.ftd2xx_real_sha256))! Aborting to avoid corrupting driver."
        return
    }
    Write-Host "  Genuine backup hash verified: $currentRealHash"
    
    if ($PSCmdlet.ShouldProcess($targetDirResolved, "Restore Scenario A: delete proxy FTD2XX.dll and restore genuine FTD2XX_REAL.dll -> FTD2XX.dll")) {
        if ($ftd2xxExists) {
            Remove-Item -Path $targetFtd2xx -Force -ErrorAction Stop
            Write-Host "  Removed proxy FTD2XX.dll."
        }
        Move-Item -Path $targetReal -Destination $targetFtd2xx -Force -ErrorAction Stop
        Write-Host "  Restored genuine FTD2XX_REAL.dll -> FTD2XX.dll."
        
        $restoredHash = Get-FileHashString $targetFtd2xx
        if ($restoredHash -ne $manifest.original_local_d2xx_sha256) {
            Write-Warning "WARNING: Restored FTD2XX.dll hash ($restoredHash) differs from original recorded hash ($($manifest.original_local_d2xx_sha256))!"
        } else {
            Write-Host "  Restored DLL hash verified: $restoredHash"
        }
        
        Remove-Item -Path $targetManifest -Force -ErrorAction Stop
        Write-Host "  Removed manifest: FTDITrace.install.json."
        
        Write-Host ""
        Write-Host "SUCCESS: Scenario A baseline restored exactly." -ForegroundColor Green
        Write-Host "  FTD2XX.dll      : Restored genuine DLL ($restoredHash)"
        Write-Host "  FTD2XX_REAL.dll : Removed"
        Write-Host "  Manifest        : Removed"
    }
} else {
    # ==================================================
    # RESTORE SCENARIO B (The Real Windows 11 Baseline)
    # Original state: NO local FTD2XX.dll; relies on SysWOW64
    # ==================================================
    Write-Host "Executing Uninstall for SCENARIO B:"
    Write-Host "  Target must have NO local FTD2XX.dll or FTD2XX_REAL.dll."
    Write-Host "  Windows DLL resolution will cleanly resume using SysWOW64\ftd2xx.dll."
    
    if ($PSCmdlet.ShouldProcess($targetDirResolved, "Restore Scenario B: remove local FTD2XX.dll and FTD2XX_REAL.dll")) {
        if ($ftd2xxExists) {
            Remove-Item -Path $targetFtd2xx -Force -ErrorAction Stop
            Write-Host "  Removed proxy FTD2XX.dll."
        }
        if ($realExists) {
            Remove-Item -Path $targetReal -Force -ErrorAction Stop
            Write-Host "  Removed temporary genuine copy FTD2XX_REAL.dll."
        }
        Remove-Item -Path $targetManifest -Force -ErrorAction Stop
        Write-Host "  Removed manifest: FTDITrace.install.json."
        
        Write-Host ""
        Write-Host "SUCCESS: Scenario B baseline restored exactly." -ForegroundColor Green
        Write-Host "  FTD2XX.dll      : Absent (Clean SysWOW64 resolution restored)"
        Write-Host "  FTD2XX_REAL.dll : Absent"
        Write-Host "  Manifest        : Absent"
    }
}

Write-Host "=================================================="
