namespace NagyiReceptjei.API.Utilities.Exceptions;

public sealed class NullFileException : Exception
{
    public NullFileException() : base("Null file.")
    {
    }
}
