using System.Diagnostics;
using UserActivities.Application.Enums;
using UserActivities.Application.Strategies;
using UserActivities.Application.ViewModels;

namespace UserActivities.Persistence.Strategies
{
    public class UserViewPageActivtyManage : IActivityStrategy
    {
        public int GetActivityTypeId()
        {
             return (int)ActivityTypes.UserViewPage;
        }
    }
}
