@echo off
dotnet new sln -n BankSystems --force

xcopy "BankSystems.ATM\Program.cs" "vendor\bin\scripts\ATM" /Y
xcopy "BankSystems.Admin\Program.cs" "vendor\bin\scripts\Admin" /Y

dotnet new classlib -n BankSystems.Core --force
erase "BankSystems.Core\Class1.cs"

dotnet new console -n BankSystems.ATM --force
xcopy "vendor\bin\scripts\ATM\Program.cs" "BankSystems.ATM\Program.cs" /Y
dotnet new console -n BankSystems.Admin --force
xcopy "vendor\bin\scripts\Admin\Program.cs" "BankSystems.Admin\Program.cs" /Y

dotnet sln BankSystems.sln add BankSystems.ATM/BankSystems.ATM.csproj
dotnet sln BankSystems.sln add BankSystems.Admin/BankSystems.Admin.csproj
dotnet sln BankSystems.sln add BankSystems.Core/BankSystems.Core.csproj

dotnet add BankSystems.ATM/BankSystems.ATM.csproj reference BankSystems.Core/BankSystems.Core.csproj
dotnet add BankSystems.Admin/BankSystems.Admin.csproj reference BankSystems.Core/BankSystems.Core.csproj

dotnet add BankSystems.Core/BankSystems.Core.csproj package Newtonsoft.Json

pause