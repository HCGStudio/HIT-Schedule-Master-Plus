#!/bin/sh

cd src/HITScheduleMasterPlus
dotnet restore
dotnet tool install ElectronNET.CLI -g
electronize build /target osx /package-json package.json