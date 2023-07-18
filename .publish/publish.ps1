# echo current directory
Write-Output "Current directory: $PWD"

$json = Get-Content -Path "./.publish/apiKeys.json" -Raw
$apiKeys = ConvertFrom-Json $json

$nugetApiKey = $apiKeys.nuget
$githubPackagesApiKey = $apiKeys.githubPackages

$LoggerVersion = "1.0.4"
$UserSecretsVersion = "1.0.5"


Write-Output "Building"
dotnet pack -o Release

# Nuget
Write-Output "Pushing to nuget"
dotnet nuget push "Release/joerivanarkel.Core.UserSecrets.$UserSecretsVersion.nupkg" --api-key $nugetApiKey --source "https://api.nuget.org/v3/index.json"
dotnet nuget push "Release/joerivanarkel.Core.Logger.$LoggerVersion.nupkg" --api-key $nugetApiKey --source "https://api.nuget.org/v3/index.json"

# Github packages
Write-Output "Pushing to github packages"
dotnet nuget push "Release/joerivanarkel.Core.UserSecrets.$UserSecretsVersion.nupkg" --api-key $githubPackagesApiKey --source "https://nuget.pkg.github.com/joerivanarkel/index.json"
dotnet nuget push "Release/joerivanarkel.Core.Logger.$LoggerVersion.nupkg" --api-key $githubPackagesApiKey --source "https://nuget.pkg.github.com/joerivanarkel/index.json"