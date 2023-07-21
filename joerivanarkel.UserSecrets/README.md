
<div class="container">
  <div class="row">
    <img src="icon.png" alt="Image Description" width="50" height="50" alt="joerivanarkelPackages Icon">
    <h1>joerivanarkel.UserSecrets</h1>
  </div>

  <div class="row">
    <a href="https://www.nuget.org/packages/joerivanarkel.UserSecrets/">
        <img src="https://img.shields.io/nuget/v/joerivanarkel.UserSecrets.svg" alt="joerivanarkel.UserSecrets">
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
# joerivanarkel.UserSecrets

This package is a simple wrapper around the [Microsoft.Extensions.Configuration.UserSecrets](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.UserSecrets/) package. It allows you to use the `IConfiguration` interface to access your user secrets.

# Contents
- [Methods](#methods)
- [Usage](#usage)

## Methods
| Class.Method | Description |
| --- | --- |
| <i>`UserSecrets.GetSecret(string secretName)`<i> | Returns the value of the secret with the given name. |
| <i>`UserSecrets.AddSecret(string key, string value)`<i> | Adds a secret with the given key and value. |

## Usage
The user secrets can be used as follows:
```csharp
var secretString = UserSecrets.GetSecret("SecretName");
```