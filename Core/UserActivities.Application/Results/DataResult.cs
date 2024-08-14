namespace UserActivities.Application.Results
{
    public class DataResult<T> : ResultModel, IDataResult<T>
    {
        public DataResult(T data, bool success, string message)
            : base(success, message)
        {
            Data = data;
        }

        public DataResult(T data, bool success)
            : base(success)
        {
            Data = data;
        }

        public T Data { get; }
    }
}
