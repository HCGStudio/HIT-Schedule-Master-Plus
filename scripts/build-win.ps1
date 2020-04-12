Set-Location ./src/HITScheduleMasterPlus
dotnet restore
dotnet tool install ElectronNET.CLI -g
electronize build /target win /package-json package.json