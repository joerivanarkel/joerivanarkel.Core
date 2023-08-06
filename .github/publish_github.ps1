$nugetDirectory = param($nugetDirectory)
$packagesApiKey = param($packagesApiKey)

$files = Get-ChildItem $nugetDirectory -Recurse -Include *.nupkg
foreach ($file in $files) {
    try {
        dotnet nuget push $file.FullName --api-key $packagesApiKey --source "https://nuget.pkg.github.com/joerivanarkel/index.json" --skip-duplicate
    }
    catch {
        Write-Warning $Error[0]
    }
}