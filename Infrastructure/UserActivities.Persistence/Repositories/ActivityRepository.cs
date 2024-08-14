using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using UserActivities.Application.Dtos;
using UserActivities.Application.Enums;
using UserActivities.Application.Repositories;
using UserActivities.Application.Results;
using UserActivities.Application.Strategies;
using UserActivities.Application.ViewModels;
using UserActivities.Domain.Entities;
using UserActivities.Persistence.Context;
using UserActivities.Persistence.Strategies;

namespace UserActivities.Persistence.Repositories
{
    public class ActivityRepository : BaseRepository<Activity>,IActivityRepository
    {
        
        private UserActivitiesApiDbContext _appDbContext { get => _context as UserActivitiesApiDbContext; }

        public ActivityRepository(UserActivitiesApiDbContext context) : base(context)
        {
         
        }

        public async Task<IResultModel> GetActivitiesByFilter(ActivityFilterDTO?     Filter)
        {
            IResultModel result;
            try
            {

                var query = _context.Activities.AsQueryable();
                
                if (Filter is not null)
                {

                    if (Filter.UserId.HasValue)
                    {
                        query = query.Where(a => a.UserId == Filter.UserId.Value);
                    }

                    if (Filter.ActivityTypeId.HasValue)
                    {
                        query = query.Where(a => a.ActivityType == Filter.ActivityTypeId.Value);
                    }

                    if (!string.IsNullOrEmpty(Filter.Description))
                    {
                        query = query.Where(a => a.Description.Contains(Filter.Description));
                    }

                    if (Filter.StartDate.HasValue)
                    {
                        query = query.Where(a => a.ActivityDate >= Filter.StartDate.Value);
                    }

                    if (Filter.EndDate.HasValue)
                    {
                        query = query.Where(a => a.ActivityDate <= Filter.EndDate.Value);
                    }
                }

                var ActivityList = await query.AsNoTracking().Include(a => a.User).ToListAsync();

                if (ActivityList?.Count > 0)
                {
                    var ActivityViewList = ActivityList.Select(x => new ActivityViewModel
                    {
                        ActivityDate = x.ActivityDate,
                        ActivityId = x.ActivityId,
                        ActivityType = x.ActivityType,
                        ActivityTypeDescription = ((ActivityTypes)x.ActivityType).ToString(),
                        Description = x.Description,
                        User = x.User.Name,
                        UserId = x.UserId
                    }).ToList();

                    return new DataResult<List<ActivityViewModel>>(ActivityViewList, true);
                }

                result = new ResultModel(false, "Veri Bulunamadı!");
            }
            catch (Exception e)
            {
                result = new ResultModel(false, e.Message);
            }
            return result;
        }
    }
}
