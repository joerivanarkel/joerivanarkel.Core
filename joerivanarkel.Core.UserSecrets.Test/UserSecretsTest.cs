using joerivanarkel.Core.UserSecrets;
using joerivanarkel.Core.UserSecrets.Exception;
using Microsoft.Extensions.Configuration;

namespace joerivanarkel.Core.UserSecrets.Test;

public class UserSecretsTest
{
    [Fact]
    // Ensure that the secret is set in the environment variables
    // Otherwise run the following command in the test project directory:
    // dotnet user-secrets init
    // dotnet user-secrets set Test 12345
    public void GetSecret_WithValidSecretName_ReturnsSecretValue()
    {
        // Arrange
        string secretName = "Test";
        string secretValue = "12345";

        // Act
        string result = UserSecrets<UserSecretsTest>.GetSecret(secretName);

        // Assert
        Assert.Equal(secretValue, result);
    }

    [Fact]
    public void GetSecret_WithInvalidSecretName_ThrowsUserSecretException()
    {
        // Arrange
        string secretName = "InvalidSecret";

        // Act & Assert
        try
        {
            UserSecrets<UserSecretsTest>.GetSecret(secretName);
        }
        catch (System.Exception ex)
        {
            Assert.IsType<UserSecretException>(ex);
            Assert.Equal($"Could not get secret {secretName} from user secrets. The secret is null or empty", ex.Message);
        }
    }
}