using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UserActivities.Application.Repositories;
using UserActivities.Domain.Entities.Common;
using UserActivities.Persistence.Context;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace UserActivities.Persistence.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        public readonly UserActivitiesApiDbContext _context;
        public BaseRepository(UserActivitiesApiDbContext context)
        {
            _context = context;
        }

        //protected readonly DbContext _context;
        //private readonly DbSet<TEntity> _dbset;
        //public BaseRepository(AppDbContext context)
        //{
        //    _context = context;
        //    _dbset = context.Set<TEntity>();
        //}


        public DbSet<T> Table => _context.Set<T>();
        public async Task<bool> AddAsync(T Model)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(Model);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> DataList)
        {
            await Table.AddRangeAsync(DataList);
            return true;
        }

        public IQueryable<T> GetAll(bool Tracking = true)
        {
            var query = Table.AsQueryable();
            if (!Tracking)
                query = query.AsNoTracking();
            return query;
        }
        public IQueryable<T> GetWhere(Expression<Func<T, bool>> Method, bool Tracking = true)
        {
            var query = Table.Where(Method);
            if (!Tracking)
                query = query.AsNoTracking();
            return query;
        }
        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> Method, bool Tracking = true)
        {
            var query = Table.AsQueryable();
            if (!Tracking)
                query = Table.AsNoTracking();
            return await query.FirstOrDefaultAsync(Method);
        }
        public bool Remove(T Model)
        {
            EntityEntry<T> entityEntry = Table.Remove(Model);
            return entityEntry.State == EntityState.Deleted;
        }        

        public  bool RemoveRange(List<T> DataList)
        {
            Table.RemoveRange(DataList);
            return true;
        }

        public async Task<int> SaveAsync()
       => await _context.SaveChangesAsync();

        public bool Update(T Model)
        {
            EntityEntry entityEntry = Table.Update(Model);
            return entityEntry.State == EntityState.Modified;
        }
    }
}
