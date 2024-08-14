using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UserActivities.Application.Repositories;
using UserActivities.Application.Services;
using UserActivities.Application.UnitOfWork;
using UserActivities.Domain.Entities.Common;

namespace UserActivities.Persistence.Services
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        public readonly IUnitOfWork _unitOfWork;
        public readonly IBaseRepository<T> _repository;

        public BaseService(IUnitOfWork unitOfWork, IBaseRepository<T> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<bool> AddAsync(T Model)
        {
            var result = await _repository.AddAsync(Model);
          await  _unitOfWork.SaveChangesAsync();
            return result;

        }

        public async Task<bool> AddRangeAsync(List<T> DataList)
        {
            var result = await _repository.AddRangeAsync(DataList);
            await _unitOfWork.SaveChangesAsync();
            return result;
        }

        public IQueryable<T> GetAll(bool Tracking = true)
        {
            return  _repository.GetAll(Tracking);
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> Method, bool Tracking = true)
        {
            return await _repository.GetSingleAsync(Method, Tracking);    
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> Method, bool Tracking = true)
        {
            return _repository.GetWhere(Method, Tracking);
                 
        }

        public  bool Remove(T Model)
        {
            var result =  _repository.Remove(Model);
            _unitOfWork.SaveChanges();
            return result;
        }

        public bool RemoveRange(List<T> DataList)
        {
           var result =  _repository.RemoveRange(DataList);
            _unitOfWork.SaveChanges();

            return result;
        }

        public async Task<int> SaveAsync()
        {
            return await _unitOfWork.SaveChangesAsync();
        }

        public bool Update(T Model)
        {
            var result =  _repository.Update(Model);
            _unitOfWork.SaveChanges();
            return result;  
        }
    }
}