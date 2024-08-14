using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserActivities.Application.Enums;
using UserActivities.Application.Strategies;
using UserActivities.Application.ViewModels;

namespace UserActivities.Persistence.Strategies
{
    public class UserLoginActivtyManage : IActivityStrategy
    {
        public int GetActivityTypeId()
        {
            return (int)ActivityTypes.UserLogin;
        }  
    }
}
