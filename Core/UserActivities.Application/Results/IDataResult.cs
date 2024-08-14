namespace UserActivities.Application.Results
{
    public interface IDataResult<out T> : IResultModel
    {
        T Data { get; }
    }
}
