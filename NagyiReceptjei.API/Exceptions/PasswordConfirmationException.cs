namespace NagyiReceptjei.API.Exceptions;

sealed class PasswordConfirmationException : Exception
{
    public PasswordConfirmationException(string message = "Password confirmation failed.") : base(message)
    {
    }
}
