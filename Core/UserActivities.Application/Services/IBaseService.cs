using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UserActivities.Domain.Entities.Common;

namespace UserActivities.Application.Services
{
    public interface IBaseService<T> where T :BaseEntity
    {
        Task<bool> AddAsync(T Model);
        Task<bool> AddRangeAsync(List<T> DataList);
        bool Remove(T Model);
        bool RemoveRange(List<T> DataList);
        bool Update(T Model);
        IQueryable<T> GetAll(bool Tracking = true);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> Method, bool Tracking = true);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> Method, bool Tracking = true);
        Task<int> SaveAsync();
    }
}
