using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserActivities.Application.Repositories;

namespace UserActivities.Application.UnitOfWork
{

    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IActivityRepository ActivityRepository { get; }
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
