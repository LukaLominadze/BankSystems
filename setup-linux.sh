#!/bin/bash

set -e  # Exit on error

dotnet new sln -n BankSystems --force

# Copy the Program.cs files (create destination dirs if needed)
mkdir -p vendor/bin/scripts/ATM
mkdir -p vendor/bin/scripts/Admin

cp -f BankSystems.ATM/Program.cs vendor/bin/scripts/ATM/
cp -f BankSystems.Admin/Program.cs vendor/bin/scripts/Admin/

dotnet new classlib -n BankSystems.Core --force
rm -f BankSystems.Core/Class1.cs

dotnet new console -n BankSystems.ATM --force
cp -f vendor/bin/scripts/ATM/Program.cs BankSystems.ATM/Program.cs

dotnet new console -n BankSystems.Admin --force
cp -f vendor/bin/scripts/Admin/Program.cs BankSystems.Admin/Program.cs

dotnet sln BankSystems.sln add BankSystems.ATM/BankSystems.ATM.csproj
dotnet sln BankSystems.sln add BankSystems.Admin/BankSystems.Admin.csproj
dotnet sln BankSystems.sln add BankSystems.Core/BankSystems.Core.csproj

dotnet add BankSystems.ATM/BankSystems.ATM.csproj reference BankSystems.Core/BankSystems.Core.csproj
dotnet add BankSystems.Admin/BankSystems.Admin.csproj reference BankSystems.Core/BankSystems.Core.csproj

dotnet add BankSystems.Core/BankSystems.Core.csproj package Newtonsoft.Json

read -p "Press Enter to continue..."
