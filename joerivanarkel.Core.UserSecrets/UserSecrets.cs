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
    }
}