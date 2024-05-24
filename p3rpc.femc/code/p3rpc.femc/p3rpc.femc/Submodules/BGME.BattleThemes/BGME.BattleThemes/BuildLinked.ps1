# Set Working Directory
Split-Path $MyInvocation.MyCommand.Path | Push-Location
[Environment]::CurrentDirectory = $PWD

Remove-Item "$env:RELOADEDIIMODS/BGME.BattleThemes/*" -Force -Recurse
dotnet publish "./BGME.BattleThemes.csproj" -c Release -o "$env:RELOADEDIIMODS/BGME.BattleThemes" /p:OutputPath="./bin/Release" /p:ReloadedILLink="true"

# Restore Working Directory
Pop-Location