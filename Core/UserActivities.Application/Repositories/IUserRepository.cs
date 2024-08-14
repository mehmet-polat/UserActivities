using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserActivities.Domain.Entities;

namespace UserActivities.Application.Repositories
{
    public interface IUserRepository :IBaseRepository<User> 
    {
    }
}
