using Microsoft.Extensions.Configuration;

namespace joerivanarkel.Core.UserSecrets
{
    public class UserSecrets<T>
        where T : class
    {
        public static string GetSecret(string secretName)
        {
            var secretConfig = new ConfigurationBuilder()
                .AddUserSecrets<T>()
                .Build();
            return secretConfig[secretName];
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
            catch (Exception)
            {
                return false;
            }

        }

    }
}