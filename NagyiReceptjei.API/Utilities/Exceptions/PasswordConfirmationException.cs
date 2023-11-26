namespace NagyiReceptjei.API.Utilities.Exceptions;

public sealed class PasswordConfirmationException : Exception
{
    public PasswordConfirmationException(string message = "Password confirmation failed.") : base(message)
    {
    }
}
