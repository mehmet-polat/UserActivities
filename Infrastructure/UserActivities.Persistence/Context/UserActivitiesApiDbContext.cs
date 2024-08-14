using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserActivities.Domain.Entities;

namespace UserActivities.Persistence.Context
{
    public class UserActivitiesApiDbContext:DbContext
    {
        public UserActivitiesApiDbContext(DbContextOptions options) : base(options) 
        { 
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Activity> Activities { get; set; }

    }
}
