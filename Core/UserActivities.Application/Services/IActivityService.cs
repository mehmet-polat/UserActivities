using UserActivities.Application.Dtos;
using UserActivities.Application.Results;
using UserActivities.Application.ViewModels;
using UserActivities.Domain.Entities;

namespace UserActivities.Application.Services
{
    public interface IActivityService : IBaseService<Activity>
    {

        public Task<IResultModel> GetActivityListByFilter(ActivityFilterDTO? Filter);
        public Task<IResultModel> AddActivity(ActivitySaveDTO Model);
        public Task<IResultModel> UpdateActivity(ActivityUpdateDTO Model);
    }

}
