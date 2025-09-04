@echo off
echo Installing required NuGet packages for LMS projects...

REM --- LMS.WebApi ---
echo Installing packages for LMS.WebApi...
dotnet add LMS.WebApi package Microsoft.AspNetCore.Swagger
dotnet add LMS.WebApi package Swashbuckle.AspNetCore
dotnet add LMS.WebApi package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add LMS.WebApi package Microsoft.Extensions.Caching.StackExchangeRedis
dotnet add LMS.WebApi package Microsoft.AspNetCore.Identity.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet tool install --global dotnet-ef


REM --- LMS.Data ---
echo Installing packages for LMS.Data...
dotnet add LMS.Data package Microsoft.EntityFrameworkCore
dotnet add LMS.Data package Microsoft.EntityFrameworkCore.SqlServer
dotnet add LMS.Data package Microsoft.EntityFrameworkCore.Tools
dotnet add LMS.Data package Npgsql.EntityFrameworkCore.PostgreSQL
dotnet add LMS.Data package MongoDB.Driver

REM --- LMS.Business ---
echo Installing packages for LMS.Business...
dotnet add LMS.Business package AutoMapper
dotnet add LMS.Business package AutoMapper.Extensions.Microsoft.DependencyInjection
dotnet add LMS.Business package FluentValidation
dotnet add LMS.Business package FluentValidation.AspNetCore

REM --- LMS.Core ---
echo Installing optional packages for LMS.Core...
dotnet add LMS.Core package FluentValidation

REM --- LMS.Cache ---
echo Installing packages for LMS.Cache...
dotnet add LMS.Cache package StackExchange.Redis

REM --- LMS.Logging ---
echo Installing packages for LMS.Logging...
dotnet add LMS.Logging package Serilog
dotnet add LMS.Logging package Serilog.AspNetCore
dotnet add LMS.Logging package Serilog.Sinks.Console
dotnet add LMS.Logging package Serilog.Sinks.File

REM --- LMS.Tests ---
echo Installing packages for LMS.Tests...
dotnet add LMS.Tests package NUnit
dotnet add LMS.Tests package Microsoft.NET.Test.Sdk
dotnet add LMS.Tests package NUnit3TestAdapter
dotnet add LMS.Tests package Moq
dotnet add LMS.Tests package FluentAssertions

echo.
echo ✅ All packages installed successfully!
pause

//---run db migration

cd LMS.WebApi
dotnet ef migrations add InitialCreate1 -p ../LMS.Data -s .
dotnet ef database update -p ../LMS.Data -s .

-- forspecific Context File
dotnet ef migrations add InitialCreate2 -c SqlDbContext -p ../LMS.Data -s .
dotnet ef database update -c SqlDbContext -p ../LMS.Data -s .
  

every updation use same command

dotnet ef migrations add SeedInitialData -p ../LMS.Data -s .
dotnet ef database update -p ../LMS.Data -s .

----to seed data or update using package manager--select your project
dotnet ef migrations add SeedInitialData --project LMS.Data --startup-project LMS.WebApi
dotnet ef database update --project LMS.Data --startup-project LMS.WebApi


dotnet ef migrations add InitialAnalyticsSchema3 -c AnalyticsDbContext -o Migrations/PostgresMigrations -p ../LMS.Data -s .
dotnet ef database update -c AnalyticsDbContext -p ../LMS.Data -s .

dotnet ef migrations add AddNewColumn -c AnalyticsDbContext
dotnet ef database update -c AnalyticsDbContext -p ../LMS.Data -s .
