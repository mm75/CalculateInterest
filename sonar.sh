#!/bin/bash

rm -rf .sonarqube

dotnet sonarscanner begin \
/k:"CalculateInterest" \
/d:sonar.host.url="http://localhost:9000" \
/d:sonar.login="bec6fccda7e17e436d7ffbee93cb99435e4b4a42"
/d:sonar.exclusions="tests/**"

dotnet build 

dotnet sonarscanner end /d:sonar.login="bec6fccda7e17e436d7ffbee93cb99435e4b4a42"

