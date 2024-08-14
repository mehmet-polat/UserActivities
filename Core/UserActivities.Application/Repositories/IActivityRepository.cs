using UserActivities.Application.Dtos;
using UserActivities.Application.Results;
using UserActivities.Domain.Entities;

namespace UserActivities.Application.Repositories
{
    public interface IActivityRepository : IBaseRepository<Activity>
    {
        Task<IResultModel> GetActivitiesByFilter(ActivityFilterDTO? Filter);
    }
}
