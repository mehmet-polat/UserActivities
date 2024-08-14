using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserActivities.Application.Dtos;
using UserActivities.Application.Repositories;
using UserActivities.Application.Results;
using UserActivities.Application.Services;
using UserActivities.Application.UnitOfWork;
using UserActivities.Domain.Entities;

namespace UserActivities.Persistence.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        public UserService(IUnitOfWork unitOfWork, IBaseRepository<User> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<IResultModel> AddUserAsync(UserSaveDTO Model)
        {

            IResultModel result;
            try
            {
                var newData = new User
                {
                    Email = Model.Email,
                    JoinDate = DateTime.Now,
                    Name = Model.Name,
                };
                var dbResult = await _repository.AddAsync(newData);
                await _unitOfWork.SaveChangesAsync();
                result = new ResultModel(dbResult, dbResult ? "Kullanıcı Başarıyla Kayıt Edildi!" : "Bir Sorun Oluştu Daha Sonra Tekar Deneyin!");
            }
            catch (Exception e)
            {
                result = new ResultModel(false, e.Message);
            }

            return result;
        }

        public async Task<IResultModel> UpdateUser(UserUpdateDTO Model)
        {
            IResultModel result;

            try
            {
                var updateData = await _repository.GetSingleAsync(x => x.UserId == Model.UserId);
                if (updateData?.UserId != null)
                {
                    updateData.Email = Model.Email;
                    updateData.Name = Model.Name;
                    var dbResult = _repository.Update(updateData);
                    _unitOfWork.SaveChanges();

                    result = new ResultModel(dbResult, dbResult ? "Kullanıcı Başarıyla Güncellendi!" : "Bir Sorun Oluştu Daha Sonra Tekar Deneyin!");
                    return result;
                }
                result = new ResultModel(false, "Kullanıcı Kaydı Bulunamadı!");
            }
            catch (Exception e)
            {
                result = new ResultModel(false, e.Message);
            }


            return result;
        }
    }
}
