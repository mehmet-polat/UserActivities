using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserActivities.Application.Repositories;
using UserActivities.Domain.Entities;
using UserActivities.Persistence.Context;

namespace UserActivities.Persistence.Repositories
{
    public class UserRepository : BaseRepository<User>,IUserRepository
    {
        public UserRepository(UserActivitiesApiDbContext context) : base(context)
        {
        }
    }
}
