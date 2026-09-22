<#
.SYNOPSIS
Uninstalls FTDITrace from TuneECU.
#>

$ErrorActionPreference = "Stop"
$TuneEcuPath = "C:\TuneECUv2.5.5"

Write-Host "Uninstalling FTDITrace from $TuneEcuPath"

if (Test-Path "$TuneEcuPath\FTD2XX_REAL.dll") {
    Remove-Item -Path "$TuneEcuPath\FTD2XX.dll" -Force
    Move-Item -Path "$TuneEcuPath\FTD2XX_REAL.dll" -Destination "$TuneEcuPath\FTD2XX.dll" -Force
    Write-Host "Restored genuine FTD2XX.dll."
} else {
    Write-Host "FTD2XX_REAL.dll not found. Proxy might not be installed."
}

Write-Host "Done."
