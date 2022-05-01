@echo off

set MSBUILD_PATH="C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\MSBuild\Current\Bin\MSBuild.exe"
set PLATFORM=x64
set CONFIGURATION=Release
set DIRECTORY_NAME=Tatelier

if exist "..\bin\%PLATFORM%\%DIRECTORY_NAME%" (
rmdir /q /s "..\bin\%PLATFORM%\%DIRECTORY_NAME%"
)

::MSBuild
if exist %MSBUILD_PATH% (
%MSBUILD_PATH% "%~dp0..\..\Tatelier.sln" /t:Rebuild /p:CONFIGURATION=%Configuration%;Platform="%PLATFORM%"
) else (
    echo MSBuild.exe が 見つかりませんでした。
)

::EXEバージョン取得
powershell .\output-tatelier-version.ps1 ".\..\bin\%PLATFORM%\%CONFIGURATION%\Tatelier.exe"

FOR /F %%a IN (ver.txt) DO SET VER=%%a

echo %VER%

::フォルダ名変更
move "..\bin\%PLATFORM%\%CONFIGURATION%" "..\bin\%PLATFORM%\%DIRECTORY_NAME%"

::ZIP作成
powershell .\output-release-zip.ps1 "..\bin\%PLATFORM%\%DIRECTORY_NAME%" "..\bin\%PLATFORM%\Tatelier-v%ver%-%CONFIGURATION%-%PLATFORM%.zip"

::デプロイはひとまず手動

    
::一時ファイル削除
del ver.txt