using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserActivities.Application.Dtos;
using UserActivities.Application.Results;
using UserActivities.Domain.Entities;

namespace UserActivities.Application.Services
{
    public interface IUserService : IBaseService<User>
    {
        public Task<IResultModel> AddUserAsync(UserSaveDTO Model);
        public Task<IResultModel> UpdateUser(UserUpdateDTO Model);

    }

}
