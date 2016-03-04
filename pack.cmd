@ECHO OFF
SET ROOT=%~dp0
ECHO Please check the verison for the package.
"%Redist%redist\nuget.exe" pack "%ROOT%nuget\LiveSDK.ObjectModel.nuspec" -OutputDirectory "%ROOT%bin\ "