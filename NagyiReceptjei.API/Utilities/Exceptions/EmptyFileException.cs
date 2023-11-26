namespace NagyiReceptjei.API.Utilities.Exceptions;

public sealed class EmptyFileException : Exception
{
    public EmptyFileException() : base("Empty file.")
    {
    }
}
