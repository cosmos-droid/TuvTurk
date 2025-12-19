namespace TuvTurk.Entities.Utilities
{
    public interface IDataResult<T> : IResult
    {
        T Data { get; }
    }
}