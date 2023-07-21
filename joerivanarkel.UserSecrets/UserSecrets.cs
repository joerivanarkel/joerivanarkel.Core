using joerivanarkel.UserSecrets.Exception;
using Microsoft.Extensions.Configuration;

namespace joerivanarkel.UserSecrets;

/// <summary>
/// A class that can get secrets from the user secrets.
/// </summary>
/// <typeparam name="T">The type of the class that is calling this class</typeparam>
public class UserSecrets<T>
    where T : class
{
    /// <summary>
    /// Gets a secret from the user secrets.
    /// </summary>
    /// <param name="secretName">The name of the secret</param>
    /// <returns>The secret</returns>
    /// <exception cref="UserSecretException">Thrown when the secret is null or empty</exception>
    /// <exception cref="UserSecretException">Thrown when the secret could not be found</exception>
    public static string GetSecret(string secretName)
    {
        try
        {
            var secretConfig = new ConfigurationBuilder()
                .AddUserSecrets<T>()
                .Build();

            if (secretConfig[secretName] == null || secretConfig[secretName] == string.Empty) throw new UserSecretException($"Could not get secret {secretName} from user secrets. The secret is null or empty");
            
            return secretConfig[secretName];
        }
        catch (UserSecretException exception)
        {
            throw exception;
        }
        catch (System.Exception)
        {
            throw new UserSecretException($"Could not get secret {secretName} from user secrets");
        }
    }

}