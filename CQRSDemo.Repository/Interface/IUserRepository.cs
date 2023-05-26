using CQRSDemo.Core.Models;
using CQRSDemo.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDemo.Repository.Interface
{
    public interface IUserRepository
    {
        public Task<List<User>> GetAllUser();

        public Task<UserAdd> AddUserData(UserAdd user);
    }
}
