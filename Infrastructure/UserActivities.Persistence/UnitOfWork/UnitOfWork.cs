using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserActivities.Application.Repositories;
using UserActivities.Application.UnitOfWork;
using UserActivities.Persistence.Context;
using UserActivities.Persistence.Repositories;

namespace UserActivities.Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UserActivitiesApiDbContext _context;
        private IUserRepository _userRepository;
        private IActivityRepository _activityRepository;

        public UnitOfWork(UserActivitiesApiDbContext context)
        {
            _context = context;
        }

        public IUserRepository UserRepository => _userRepository = _userRepository ?? new UserRepository(_context);
        public IActivityRepository ActivityRepository => _activityRepository = _activityRepository ?? new ActivityRepository(_context);

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
