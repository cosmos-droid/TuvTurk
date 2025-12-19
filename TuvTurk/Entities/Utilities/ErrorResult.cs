using Entities.Utilities;

namespace TuvTurk.Entities.Utilities
{
    public class ErrorResult : Result
    {
        public ErrorResult(string message) : base(success: false, message)
        {
        }

        public ErrorResult() : base(success: false)
        {
        }

    }
}