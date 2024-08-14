using System.Diagnostics;
using UserActivities.Application.Enums;
using UserActivities.Application.Strategies;
using UserActivities.Application.ViewModels;

namespace UserActivities.Persistence.Strategies
{
    public class UserProcessActivtyManage : IActivityStrategy
    {
        public int GetActivityTypeId()
        {
            return (int)ActivityTypes.UserProcess;
        }
    }
}
