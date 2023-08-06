$nugetDirectory = param($nugetDirectory)
$nugetApiKey = param($nugetApiKey)

$files = Get-ChildItem $nugetDirectory -Recurse -Include *.nupkg
foreach($file in $files) {
    try {
        dotnet nuget push $file --api-key $nugetApiKey  --source "https://api.nuget.org/v3/index.json" --skip-duplicate
    }
    catch {
        Write-Warning $Error[0]
    }
}