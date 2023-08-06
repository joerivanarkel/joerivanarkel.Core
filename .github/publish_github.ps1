$nugetDirectory = $args[0]
$packagesApiKey = $args[1]

$files = Get-ChildItem $nugetDirectory -Recurse -Include *.nupkg
foreach ($file in $files) {
    try {
        dotnet nuget push $file.FullName --api-key $packagesApiKey --source "https://nuget.pkg.github.com/joerivanarkel/index.json" --skip-duplicate
    }
    catch {
        Write-Warning $Error[0]
    }
}