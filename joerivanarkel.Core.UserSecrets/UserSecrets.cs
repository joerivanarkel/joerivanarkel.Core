using joerivanarkel.Core.UserSecrets.Exception;
using Microsoft.Extensions.Configuration;

namespace joerivanarkel.Core.UserSecrets
{
    public class UserSecrets<T>
        where T : class
    {
        public static string GetSecret(string secretName)
        {
            try
            {
                var secretConfig = new ConfigurationBuilder()
                    .AddUserSecrets<T>()
                    .Build();
                return secretConfig[secretName];
            }
            catch (System.Exception)
            {
                throw new UserSecretException($"Could not get secret {secretName} from user secrets");
            }
        }

        public static bool AddSecret(string key, string value)
        {
            try
            {
                var secretConfig = new ConfigurationBuilder()
                    .AddUserSecrets<T>()
                    .Build();
                secretConfig[key] = value;
                return true;
            }
            catch (System.Exception)
            {
                throw new UserSecretException($"Could not add secret {key} to user secrets");
            }
        }

    }
}