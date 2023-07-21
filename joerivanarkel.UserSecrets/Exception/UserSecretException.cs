namespace joerivanarkel.UserSecrets.Exception;

using System;

internal class UserSecretException : Exception
{
    internal UserSecretException(string message) : base(message) {}
}
