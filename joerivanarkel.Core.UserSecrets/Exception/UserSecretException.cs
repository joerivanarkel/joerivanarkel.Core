namespace joerivanarkel.Core.UserSecrets.Exception;

using System;

public class UserSecretException : Exception
{
    public UserSecretException(string message) : base(message) {}
}
