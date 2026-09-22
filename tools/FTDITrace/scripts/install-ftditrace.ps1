<#
.SYNOPSIS
Safely installs FTDITrace proxy into a TuneECU directory.

.DESCRIPTION
This script safely injects the FTDITrace proxy DLL into a target TuneECU directory.
It creates a backup of genuine FTD2XX.dll as FTD2XX_REAL.dll.
It is strictly conservative and will NEVER overwrite an existing FTD2XX_REAL.dll backup.

.PARAMETER TuneECUDir
Path to the target TuneECU folder containing the genuine FTD2XX.dll.

.PARAMETER ProxyDll
Path to the FTDITrace proxy FTD2XX.dll to be installed. Defaults to ..\FTD2XX.dll relative to script.

.PARAMETER RealD2xxPath
Optional path to an explicit genuine FTD2XX.dll to use as the backup reference.

.EXAMPLE
.\install-ftditrace.ps1 -TuneECUDir "C:\TuneECUv2.5.5"
#>

[CmdletBinding(SupportsShouldProcess = $true)]
param(
    [Parameter(Position = 0, Mandatory = $false)]
    [string]$TuneECUDir,

    [Parameter(Position = 1, Mandatory = $false)]
    [string]$ProxyDll = (Join-Path $PSScriptRoot "..\FTD2XX.dll"),

    [Parameter(Mandatory = $false)]
    [string]$RealD2xxPath
)

$ErrorActionPreference = "Stop"

function Get-FileHashString([string]$filePath) {
    if (Test-Path $filePath) {
        $h = Get-FileHash -Path $filePath -Algorithm SHA256
        return $h.Hash
    }
    return "<not found>"
}

Write-Host "=================================================="
Write-Host " FTDITrace Conservative Installer"
Write-Host "=================================================="

# 1. Resolve TuneECUDir
if ([string]::IsNullOrWhiteSpace($TuneECUDir)) {
    # Default to TuneECU directory in root or prompt
    $TuneECUDir = "C:\TuneECUv2.5.5"
    Write-Host "No -TuneECUDir specified. Using default: $TuneECUDir"
}

if (-Not (Test-Path $TuneECUDir)) {
    Write-Error "Target directory does not exist: $TuneECUDir"
    return
}

$targetDirResolved = (Resolve-Path $TuneECUDir).Path
Write-Host "Target Directory : $targetDirResolved"

# 2. Resolve Proxy DLL
if (-Not (Test-Path $ProxyDll)) {
    Write-Error "FTDITrace proxy DLL not found at: $ProxyDll. Please build it first."
    return
}
$proxyResolved = (Resolve-Path $ProxyDll).Path
$proxyHash = Get-FileHashString $proxyResolved
Write-Host "Proxy DLL Source : $proxyResolved"
Write-Host "Proxy SHA-256    : $proxyHash"
Write-Host "--------------------------------------------------"

$targetFtd2xx = Join-Path $targetDirResolved "FTD2XX.dll"
$targetReal   = Join-Path $targetDirResolved "FTD2XX_REAL.dll"

$ftd2xxExists = Test-Path $targetFtd2xx
$realExists   = Test-Path $targetReal

# Check Cases
if ($ftd2xxExists -and -not $realExists) {
    # ==================================================
    # CASE A: Clean original TuneECU installation
    # ==================================================
    Write-Host "Detected State: CASE A (Clean original TuneECU installation)."
    $origHash = Get-FileHashString $targetFtd2xx
    Write-Host "Original FTD2XX.dll SHA-256: $origHash"
    Write-Host ""
    Write-Host "Planned actions:"
    Write-Host "  1. Back up: $targetFtd2xx -> $targetReal"
    Write-Host "  2. Install: $proxyResolved -> $targetFtd2xx"

    if ($PSCmdlet.ShouldProcess($targetDirResolved, "Install FTDITrace proxy (backup genuine to FTD2XX_REAL.dll)")) {
        # Perform move (safe backup)
        Move-Item -Path $targetFtd2xx -Destination $targetReal -ErrorAction Stop
        Write-Host "Backed up genuine FTD2XX.dll to FTD2XX_REAL.dll"

        # Perform copy (install proxy)
        Copy-Item -Path $proxyResolved -Destination $targetFtd2xx -ErrorAction Stop
        Write-Host "Installed FTDITrace proxy as FTD2XX.dll"

        # Verification
        $installedRealHash  = Get-FileHashString $targetReal
        $installedProxyHash = Get-FileHashString $targetFtd2xx
        Write-Host ""
        Write-Host "Verification:"
        Write-Host "  FTD2XX_REAL.dll SHA-256 : $installedRealHash"
        Write-Host "  FTD2XX.dll      SHA-256 : $installedProxyHash"

        if ($installedRealHash -eq $origHash -and $installedProxyHash -eq $proxyHash) {
            Write-Host "SUCCESS: Installation completed safely and hashes verified."
        } else {
            Write-Warning "Hash mismatch after installation! Please verify files manually."
        }
    }

} elseif ($ftd2xxExists -and $realExists) {
    # ==================================================
    # CASE B: FTDITrace appears already installed
    # ==================================================
    $currentFtd2xxHash = Get-FileHashString $targetFtd2xx
    $currentRealHash   = Get-FileHashString $targetReal
    Write-Host "Detected State: CASE B (Both FTD2XX.dll and FTD2XX_REAL.dll already exist)."
    Write-Host "  Existing FTD2XX.dll      SHA-256: $currentFtd2xxHash"
    Write-Host "  Existing FTD2XX_REAL.dll SHA-256: $currentRealHash"
    Write-Host "  Source Proxy DLL         SHA-256: $proxyHash"
    Write-Host ""
    Write-Error "REFUSAL: FTD2XX_REAL.dll already exists in target directory. Overwriting FTD2XX_REAL.dll is forbidden to protect genuine drivers. If you wish to re-install or update proxy, run uninstall-ftditrace.ps1 first."
    return

} elseif (-not $ftd2xxExists -and $realExists) {
    # ==================================================
    # CASE C: Only FTD2XX_REAL.dll exists
    # ==================================================
    $currentRealHash = Get-FileHashString $targetReal
    Write-Host "Detected State: CASE C (Only FTD2XX_REAL.dll exists; FTD2XX.dll is missing)."
    Write-Host "  Existing FTD2XX_REAL.dll SHA-256: $currentRealHash"
    Write-Host ""
    Write-Error "REFUSAL: Incomplete state detected. FTD2XX.dll is missing but FTD2XX_REAL.dll is present. Refusing to guess state. Restore genuine DLL manually or with uninstall script before proceeding."
    return

} else {
    # ==================================================
    # CASE D: Neither exists
    # ==================================================
    Write-Host "Detected State: CASE D (Neither FTD2XX.dll nor FTD2XX_REAL.dll exists in $targetDirResolved)."
    if (-not [string]::IsNullOrWhiteSpace($RealD2xxPath) -and (Test-Path $RealD2xxPath)) {
        Write-Host "Explicit genuine DLL provided at: $RealD2xxPath"
        $explicitHash = Get-FileHashString $RealD2xxPath
        Write-Host "Explicit Genuine SHA-256: $explicitHash"
        if ($PSCmdlet.ShouldProcess($targetDirResolved, "Install explicit genuine DLL as FTD2XX_REAL.dll and proxy as FTD2XX.dll")) {
            Copy-Item -Path $RealD2xxPath -Destination $targetReal -ErrorAction Stop
            Copy-Item -Path $proxyResolved -Destination $targetFtd2xx -ErrorAction Stop
            Write-Host "SUCCESS: Installed from explicit genuine DLL reference."
        }
    } else {
        Write-Error "ABORT: No FTD2XX.dll found in $targetDirResolved. TuneECU requires genuine FTDI driver installed."
        return
    }
}
Write-Host "=================================================="
