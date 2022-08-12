git clean -fdx
dotnet add package Verify.NUnit --version 17.4.1
dotnet restore --force
dotnet test

pause
git clean -fdx
dotnet add package Verify.NUnit --version 17.4.2
dotnet restore --force
dotnet test
 
#pause
#git clean -fdx
#dotnet add package Verify.NUnit --version 17.9.0
#dotnet restore --force
#dotnet test
