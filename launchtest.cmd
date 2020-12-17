set testEnvironment=%1
set browser=%2 
dotnet clean
dotnet build
dotnet test bin\Debug\SpecFlowSeleniumTesting.dll --logger "console;verbosity=detailed"