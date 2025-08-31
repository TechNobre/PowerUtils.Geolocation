dotnet tool restore
dotnet restore
dotnet build --no-restore
dotnet stryker -tp tests/PowerUtils.Geolocation.Tests/PowerUtils.Geolocation.Tests.csproj --reporter json --reporter progress --reporter cleartext --reporter html -o
