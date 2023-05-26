using CQRSDemo.Core.Models;
using CQRSDemo.Data.ViewModel;
using CQRSDemo.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDemo.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly CIPlatformContext _CIPlatformContext;

        public UserRepository(CIPlatformContext CIPlatformContext)
        {
            _CIPlatformContext = CIPlatformContext;
        }

        public async Task<List<User>> GetAllUser()
        {
            List<User> user = _CIPlatformContext.Users.ToList();
            return user;
        }
        
        public async Task<UserAdd> AddUserData(UserAdd user)
        {
            User user1 = new User();
            user1.FirstName = user.FirstName;
            user1.LastName = user.LastName; 
            user1.Email = user.Email;
            user1.Password = user.Password;
            user1.ProfileText = user.ProfileText;
            user1.Role = user.Role;
            user1.Status = user.Status;
            user1.EmployeeId = user.EmployeeId;
            user1.CityId = user.CityId;
            user1.CountryId = user.CountryId;
            user1.Department = user.Department;

            _CIPlatformContext.Users.Add(user1);
            _CIPlatformContext.SaveChanges();
            return null;
        }
    }
}
