#!/bin/bash
# Create solution
dotnet new sln -n LMS

# Create projects
dotnet new webapi -n LMS.WebApi
dotnet new classlib -n LMS.Models
dotnet new classlib -n LMS.Data
dotnet new classlib -n LMS.Core
dotnet new classlib -n LMS.Business
dotnet new classlib -n LMS.Cache
dotnet new classlib -n LMS.Logging
dotnet new nunit -n LMS.Tests
dotnet new classlib -n LMS.Deploy

# Add projects to solution
dotnet sln LMS.sln add LMS.WebApi LMS.Models LMS.Data LMS.Core LMS.Business LMS.Cache LMS.Logging LMS.Tests LMS.Deploy

# Add project references

dotnet add LMS.WebApi reference LMS.Models LMS.Business LMS.Core LMS.Cache LMS.Logging
dotnet add LMS.Business reference LMS.Models LMS.Data LMS.Core LMS.Cache LMS.Logging
dotnet add LMS.Data reference LMS.Models LMS.Core
dotnet add LMS.Cache reference LMS.Core
dotnet add LMS.Logging reference LMS.Core
dotnet add LMS.Tests reference LMS.Business LMS.Core LMS.Models LMS.Cache LMS.Logging

echo "Solution and projects created successfully!"

