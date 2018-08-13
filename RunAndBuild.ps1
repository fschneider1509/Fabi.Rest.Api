$buildCommand = "dotnet build"
$runCommand = "dotnet run --project .\Web\Fabi.Rest.Api.Web\Fabi.Rest.Api.Web.csproj"

Invoke-Expression $buildCommand
Invoke-Expression $runCommand