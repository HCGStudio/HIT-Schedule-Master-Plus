#!/bin/sh

cd src/HITScheduleMasterPlus
dotnet restore
dotnet tool install ElectronNET.CLI -g
electronize build /target linux /package-json package.json