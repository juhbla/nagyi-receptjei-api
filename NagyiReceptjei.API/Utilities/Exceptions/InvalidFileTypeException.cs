namespace NagyiReceptjei.API.Utilities.Exceptions;

public sealed class InvalidFileTypeException : Exception
{
    public InvalidFileTypeException() : base("Invalid file type.")
    {
    }
}
