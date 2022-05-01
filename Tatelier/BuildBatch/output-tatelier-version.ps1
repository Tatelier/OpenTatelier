# @powershell -NoProfile -ExecutionPolicy unrestricted -Command "Start-Process PowerShell.exe -Verb runas"

# Write-Host "Hello, world"
$ver=[System.Diagnostics.FileVersionInfo]::GetVersionInfo($Args[0]).FileVersion
[System.IO.File]::WriteAllText("ver.txt", $ver, [System.Text.Encoding]::ASCII)