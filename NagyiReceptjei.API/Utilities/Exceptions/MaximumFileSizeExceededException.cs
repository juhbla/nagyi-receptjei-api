namespace NagyiReceptjei.API.Utilities.Exceptions;

public sealed class MaximumFileSizeExceededException : Exception
{
    public MaximumFileSizeExceededException() : base("Maximum file size exceeded.")
    {
    }
}
