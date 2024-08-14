using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserActivities.Application.Results
{
    public interface IResultModel
    {
        bool Success { get; }
        string Message { get; }
    }
}
