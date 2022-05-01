
$slnPath = Convert-Path "..\..\Tatelier.sln"

Set-Location "C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\MSBuild\Current\Bin"

Start-Process -FilePath msbuild.exe -ArgumentList $slnPath -Wait