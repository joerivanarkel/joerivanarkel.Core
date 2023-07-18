# joerivanarkel.Core.UserSecrets

This package is a simple wrapper around the [Microsoft.Extensions.Configuration.UserSecrets](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.UserSecrets/) package. It allows you to use the `IConfiguration` interface to access your user secrets.

## Classes
| Class.Method | Description |
| --- | --- |
| <u>`UserSecrets.GetSecret(string secretName)`<u> | Returns the value of the secret with the given name. |
| <u>`UserSecrets.AddSecret(string key, string value)`<u> | Adds a secret with the given key and value. |