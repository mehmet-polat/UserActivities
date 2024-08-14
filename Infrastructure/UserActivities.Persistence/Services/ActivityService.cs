using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using System.Linq.Expressions;
using UserActivities.Application.Dtos;
using UserActivities.Application.Enums;
using UserActivities.Application.Repositories;
using UserActivities.Application.Results;
using UserActivities.Application.Services;
using UserActivities.Application.Strategies;
using UserActivities.Application.UnitOfWork;
using UserActivities.Application.ViewModels;
using UserActivities.Domain.Entities;
using UserActivities.Persistence.Strategies;

namespace UserActivities.Persistence.Services
{
    public class ActivityService : BaseService<UserActivities.Domain.Entities.Activity>, IActivityService
    {

        private readonly IServiceProvider _serviceProvider;

        public ActivityService(IUnitOfWork unitOfWork, IBaseRepository<UserActivities.Domain.Entities.Activity> repository, IServiceProvider serviceProvider) : base(unitOfWork, repository)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<IResultModel> AddActivity(ActivitySaveDTO Model)
        {

            IResultModel result;

            try
            {


                IActivityStrategy? strategy = Model.ActivityType switch
                {
                    ActivityTypes.UserLogin => _serviceProvider.GetService<UserLoginActivtyManage>(),
                    ActivityTypes.UserViewPage => _serviceProvider.GetService<UserViewPageActivtyManage>(),
                    ActivityTypes.UserProcess => _serviceProvider.GetService<UserProcessActivtyManage>(),
                    _ => throw new ArgumentException("Aktivite Tipi Geçersiz!")
                };

                int ActivityTypeId = strategy.GetActivityTypeId();



                var newData = new UserActivities.Domain.Entities.Activity
                {
                    ActivityDate = Model.ActivityDate,
                    ActivityType = ActivityTypeId,
                    Description = Model.Description,
                    UserId = Model.UserId,
                };

                var dbResult = await _repository.AddAsync(newData);
                await _unitOfWork.SaveChangesAsync();
                result = new ResultModel(dbResult, dbResult ? "Aktivite Başarıyla Güncellendi!" : "Bir Sorun Oluştu Daha Sonra Tekar Deneyin!");
                return result;

            }
            catch (Exception e)
            {
                result = new ResultModel(false, e.Message);

            }
            return result;

        }

        public async Task<IResultModel> GetActivityListByFilter(ActivityFilterDTO? Filter)
        {
            IResultModel result;

            try
            {

                if (Filter is not null)
                {
                   
                    if (Filter.ActivityType.HasValue)
                    {
                        IActivityStrategy? strategy = Filter.ActivityType switch
                        {
                            ActivityTypes.UserLogin => _serviceProvider.GetService<UserLoginActivtyManage>(),
                            ActivityTypes.UserViewPage => _serviceProvider.GetService<UserViewPageActivtyManage>(),
                            ActivityTypes.UserProcess => _serviceProvider.GetService<UserProcessActivtyManage>(),
                            _ => null
                        };
                        
                        Filter.ActivityTypeId = strategy?.GetActivityTypeId(); ;
                    }                  
                }
                
                result = await _unitOfWork.ActivityRepository.GetActivitiesByFilter(Filter);

            }
            catch (Exception e)
            {
                result = new ResultModel(false, e.Message);
            }

            return result;
        }

        public async Task<IResultModel> UpdateActivity(ActivityUpdateDTO Model)
        {
            IResultModel result;
            try
            {


                var data = await _repository.GetSingleAsync(x => x.ActivityId == Model.ActivityId);
                if (data?.ActivityId > 0)
                {

                    IActivityStrategy? strategy = Model.ActivityType switch
                    {
                        ActivityTypes.UserLogin => _serviceProvider.GetService<UserLoginActivtyManage>(),
                        ActivityTypes.UserViewPage => _serviceProvider.GetService<UserViewPageActivtyManage>(),
                        ActivityTypes.UserProcess => _serviceProvider.GetService<UserProcessActivtyManage>(),
                        _ => throw new ArgumentException("Aktivite Tipi Geçersiz!")
                    };

                    int ActivityTypeId = strategy.GetActivityTypeId();

                    data.ActivityType = (int)ActivityTypeId;
                    data.Description = Model.Description;

                    var dbResult = _repository.Update(data);
                    _unitOfWork.SaveChanges();
                    result = new ResultModel(dbResult, dbResult ? "Aktivite Başarıyla Güncellendi!" : "Bir Sorun Oluştu Daha Sonra Tekar Deneyin!");
                    return result;
                }
                result = new ResultModel(false, "Aktivite Kaydı Bulunamadı!");
            }
            catch (Exception e)
            {
                result = new ResultModel(false, e.Message);

            }


            return result;
        }
    }
}
