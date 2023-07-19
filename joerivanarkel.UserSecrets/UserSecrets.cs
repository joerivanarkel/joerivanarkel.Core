using joerivanarkel.UserSecrets.Exception;
using Microsoft.Extensions.Configuration;

namespace joerivanarkel.UserSecrets
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
}