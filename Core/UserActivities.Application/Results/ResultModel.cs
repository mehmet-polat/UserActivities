namespace UserActivities.Application.Results
{
    public class ResultModel : IResultModel
    {
        public ResultModel(bool success, string message)
            : this(success)
        {
            Message = message;
        }

        public ResultModel(bool success)
        {
            Success = success;
        }

        public bool Success { get; }
        public string Message { get; }
    }
}
