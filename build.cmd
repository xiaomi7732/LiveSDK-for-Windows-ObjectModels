ECHO OFF
SET ROOT=%~dp0
msbuild "%ROOT%Win81\LiveSDK-for-Windows-ObjectModels.sln" /p:Configuration=Release
msbuild "%ROOT%Win10\LiveSDK.ObjectModel\LiveSDK.ObjectModel.sln" /p:Configuration=Release