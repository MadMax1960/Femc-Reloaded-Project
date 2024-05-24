# Set Working Directory
Split-Path $MyInvocation.MyCommand.Path | Push-Location
[Environment]::CurrentDirectory = $PWD

Remove-Item "$env:RELOADEDIIMODS/Unreal.ObjectsEmitter.Reloaded/*" -Force -Recurse
dotnet publish "./Unreal.ObjectsEmitter.Reloaded.csproj" -c Release -o "$env:RELOADEDIIMODS/Unreal.ObjectsEmitter.Reloaded" /p:OutputPath="./bin/Release" /p:ReloadedILLink="true"

# Restore Working Directory
Pop-Location