#!/bin/bash

rm -rf .sonarqube
find tests/ -type f -name "*coverage.opencover.xml*" -exec rm -f {} \;

dotnet test tests/Application/CalculateInterest.Application.Tests/CalculateInterest.Application.Tests.csproj /p:CollectCoverage=true /p:CoverletOutputFormat=opencover
dotnet test tests/Presentation/CalculateInterest.Rate.API.Tests/CalculateInterest.Rate.API.Tests.csproj /p:CollectCoverage=true /p:CoverletOutputFormat=opencover
dotnet test tests/Presentation/CalculateInterest.Compute.API.Tests/CalculateInterest.Compute.API.Tests.csproj /p:CollectCoverage=true /p:CoverletOutputFormat=opencover

dotnet sonarscanner begin \
/k:"CalculateInterest" \
/d:sonar.host.url="http://localhost:9000" \
/d:sonar.login="bec6fccda7e17e436d7ffbee93cb99435e4b4a42" \
/d:sonar.cs.opencover.reportsPaths="tests/Application/CalculateInterest.Application.Tests/coverage.opencover.xml,tests/Presentation/CalculateInterest.Rate.API.Tests/coverage.opencover.xml,tests/Presentation/CalculateInterest.Compute.API.Tests/coverage.opencover.xml"
/d:sonar.coverage.exclusions="tests/**"

dotnet build 

dotnet sonarscanner end /d:sonar.login="bec6fccda7e17e436d7ffbee93cb99435e4b4a42"

