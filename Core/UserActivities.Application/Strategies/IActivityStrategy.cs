using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserActivities.Application.ViewModels;

namespace UserActivities.Application.Strategies
{
    public interface IActivityStrategy
    {
        int GetActivityTypeId();
        
        
    }

}
