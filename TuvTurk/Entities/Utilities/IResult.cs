namespace TuvTurk.Entities.Utilities
{
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
    }
}