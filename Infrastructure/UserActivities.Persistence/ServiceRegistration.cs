using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserActivities.Application.Repositories;
using UserActivities.Application.Services;
using UserActivities.Application.Strategies;
using UserActivities.Application.UnitOfWork;
using UserActivities.Persistence.Context;
using UserActivities.Persistence.Repositories;
using UserActivities.Persistence.Services;
using UserActivities.Persistence.Strategies;
using UserActivities.Persistence.UnitOfWorks;


namespace UserActivities.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services,IConfiguration configuration)
        {
            var _connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<UserActivitiesApiDbContext>(options => options.UseSqlServer(_connectionString));

            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IActivityRepository, ActivityRepository>();
            services.AddScoped<IActivityService,ActivityService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IActivityStrategy, UserLoginActivtyManage>();
            services.AddScoped<IActivityStrategy, UserViewPageActivtyManage>();
            services.AddScoped<IActivityStrategy, UserProcessActivtyManage>();

            services.AddScoped<UserLoginActivtyManage>();
            services.AddScoped<UserViewPageActivtyManage>();
            services.AddScoped<UserProcessActivtyManage>();

        }
    }
}
