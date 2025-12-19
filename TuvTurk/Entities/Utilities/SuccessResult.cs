namespace TuvTurk.Entities.Utilities
{
    using global::Entities.Utilities;
    public class SuccessResult : Result
    {
        public SuccessResult(string message) : base(success: true, message)
        {
        }

        public SuccessResult() : base(success: true)
        {
        }
    }
}