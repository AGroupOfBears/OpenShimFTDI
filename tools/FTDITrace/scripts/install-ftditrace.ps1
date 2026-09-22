<#
.SYNOPSIS
Installs FTDITrace into TuneECU for reference capture.

.DESCRIPTION
This script safely injects the FTDITrace proxy DLL into the TuneECU directory.
It renames the genuine FTD2XX.dll to FTD2XX_REAL.dll so the proxy can load it.

.EXAMPLE
.\install-ftditrace.ps1
#>

$ErrorActionPreference = "Stop"

$TuneEcuPath = "C:\TuneECUv2.5.5"
$ProxyDll = "..\FTD2XX.dll"

Write-Host "Installing FTDITrace to $TuneEcuPath"

if (-Not (Test-Path "$TuneEcuPath\FTD2XX.dll")) {
    if (Test-Path "$TuneEcuPath\FTD2XX_REAL.dll") {
        Write-Host "Already installed (FTD2XX_REAL.dll found)."
    } else {
        Write-Error "FTD2XX.dll not found in $TuneEcuPath. Is this a genuine TuneECU installation?"
    }
} else {
    Move-Item -Path "$TuneEcuPath\FTD2XX.dll" -Destination "$TuneEcuPath\FTD2XX_REAL.dll" -Force
    Write-Host "Backed up genuine FTD2XX.dll to FTD2XX_REAL.dll"
}

if (-Not (Test-Path $ProxyDll)) {
    Write-Error "Proxy DLL not found at $ProxyDll. Please build it first."
}

Copy-Item -Path $ProxyDll -Destination "$TuneEcuPath\FTD2XX.dll" -Force
Write-Host "Injected FTDITrace FTD2XX.dll"

Write-Host "Done. Open TuneECU with a genuine cable connected to trace D2XX."
