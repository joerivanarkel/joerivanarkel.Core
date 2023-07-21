<div class="container">
  <div class="row">
    <img src="icon.png" alt="Image Description" width="50" height="50" alt="joerivanarkelPackages Icon">
    <h1>joerivanarkel.Packages</h1>
  </div>

  <div class="row">
    <a href="https://github.com/joerivanarkel/joerivanarkel.Packages/actions/workflows/dotnet.yml">
      <img src="https://github.com/joerivanarkel/joerivanarkel.Packages/actions/workflows/dotnet.yml/badge.svg" alt=".NET & Deploy Package, Workflow Status Badge">
    </a>
  </div>
</div>

<style>
  .container {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
  }

  .row {
    display: flex;
    align-items: center;
    justify-content: center;
    margin-bottom: 10px;
  }

  .row img {
    margin-bottom: 10px;
    margin-right: 10px;
  }
</style>

In this repository, the owner has published packages that they use in their own projects. These packages are available on both [NuGet](https://www.nuget.org/profiles/joerivanarkel) and in this repository as Github Packages.

These packages vary from simple wrappers around existing packages to custom packages that are used in multiple projects. The packages are listed [below](#packages). For more information about a specific package, click on the package name. This will take you to the package's README file. This file contains information about the package, such as how to use it.

## Packages
| Package | Version | Description |
| --- | --- | --- |
| [joerivanarkel.UserSecrets](./joerivanarkel.UserSecrets/README.md) | [![joerivanarkel.UserSecrets](https://img.shields.io/nuget/v/joerivanarkel.UserSecrets.svg)](https://www.nuget.org/packages/joerivanarkel.UserSecrets/) | This package is a simple wrapper around the [Microsoft.Extensions.Configuration.UserSecrets](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.UserSecrets/) package. |
| [joerivanarkel.Logger](./joerivanarkel.Logger/README.md) | [![joerivanarkel.Logger](https://img.shields.io/nuget/v/joerivanarkel.Logger.svg)](https://www.nuget.org/packages/joerivanarkel.Logger/) | This package is a custom logger that logs to a file. |
| [joerivanarkel.FileHandler](./joerivanarkel.FileHandler/README.md) | [![joerivanarkel.FileHandler](https://img.shields.io/nuget/v/joerivanarkel.FileHandler.svg)](https://www.nuget.org/packages/joerivanarkel.FileHandler/) | This package which handles read and write operations to files. |

