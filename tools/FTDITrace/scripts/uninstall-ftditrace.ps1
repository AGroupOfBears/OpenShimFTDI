<#
.SYNOPSIS
Safely uninstalls FTDITrace and restores genuine FTD2XX.dll.

.DESCRIPTION
Restores genuine FTD2XX_REAL.dll to FTD2XX.dll in the specified TuneECU folder.
Refuses to touch System32, SysWOW64, or unrelated driver folders.

.PARAMETER TuneECUDir
Path to the target TuneECU folder. Defaults to C:\TuneECUv2.5.5.

.EXAMPLE
.\uninstall-ftditrace.ps1 -TuneECUDir "C:\TuneECUv2.5.5"
#>

[CmdletBinding(SupportsShouldProcess = $true)]
param(
    [Parameter(Position = 0, Mandatory = $false)]
    [string]$TuneECUDir
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
Write-Host " FTDITrace Safe Uninstaller"
Write-Host "=================================================="

if ([string]::IsNullOrWhiteSpace($TuneECUDir)) {
    $TuneECUDir = "C:\TuneECUv2.5.5"
    Write-Host "No -TuneECUDir specified. Using default: $TuneECUDir"
}

if (-Not (Test-Path $TuneECUDir)) {
    Write-Error "Target directory does not exist: $TuneECUDir"
    return
}

$targetDirResolved = (Resolve-Path $TuneECUDir).Path
Write-Host "Target Directory : $targetDirResolved"

$targetFtd2xx = Join-Path $targetDirResolved "FTD2XX.dll"
$targetReal   = Join-Path $targetDirResolved "FTD2XX_REAL.dll"

if (-Not (Test-Path $targetReal)) {
    Write-Host "State: FTD2XX_REAL.dll not found in $targetDirResolved."
    if (Test-Path $targetFtd2xx) {
        $currHash = Get-FileHashString $targetFtd2xx
        Write-Host "Current FTD2XX.dll SHA-256: $currHash"
        Write-Host "No backup file FTD2XX_REAL.dll exists. The proxy may already be uninstalled or genuine DLL is already in place."
    } else {
        Write-Host "Neither FTD2XX.dll nor FTD2XX_REAL.dll exists in $targetDirResolved."
    }
    Write-Host "No restoration action taken."
    return
}

$realHash  = Get-FileHashString $targetReal
$proxyHash = Get-FileHashString $targetFtd2xx

Write-Host "Genuine Backup (FTD2XX_REAL.dll) SHA-256 : $realHash"
Write-Host "Current Active (FTD2XX.dll)      SHA-256 : $proxyHash"
Write-Host ""
Write-Host "Planned actions:"
Write-Host "  1. Remove active proxy: $targetFtd2xx"
Write-Host "  2. Restore genuine:     $targetReal -> $targetFtd2xx"

if ($PSCmdlet.ShouldProcess($targetDirResolved, "Restore genuine FTD2XX_REAL.dll to FTD2XX.dll")) {
    if (Test-Path $targetFtd2xx) {
        Remove-Item -Path $targetFtd2xx -Force -ErrorAction Stop
        Write-Host "Removed proxy FTD2XX.dll."
    }
    Move-Item -Path $targetReal -Destination $targetFtd2xx -Force -ErrorAction Stop
    Write-Host "Restored genuine FTD2XX_REAL.dll to FTD2XX.dll."

    $restoredHash = Get-FileHashString $targetFtd2xx
    Write-Host ""
    Write-Host "Verification:"
    Write-Host "  Restored FTD2XX.dll SHA-256: $restoredHash"
    if ($restoredHash -eq $realHash) {
        Write-Host "SUCCESS: Genuine DLL restored and verified matching backup."
    } else {
        Write-Warning "Hash mismatch after restore! Please check file manually."
    }
}

Write-Host "=================================================="
