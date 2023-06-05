using CQRSDemo.Core.Models;
using CQRSDemo.Data.ViewModel;
using CQRSDemo.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using CQRSDemo.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQRSDemo.Repository.DTOs;

namespace CQRSDemo.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly CIPlatformContext _CIPlatformContext;

        public UserRepository(CIPlatformContext CIPlatformContext)
        {
            _CIPlatformContext = CIPlatformContext;
        }

        public async Task<IEnumerable<User>> GetAllUser(Paging dto)
        {
            return await _CIPlatformContext.Users.Pagination(dto.Page, dto.PageSize);
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
            if (user.UserImg != null)
            {
                user1.Avatar = user.UserImg.FileName;

                var path = Path.Combine(Directory.GetCurrentDirectory(), "Images", user.UserImg.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await user.UserImg.CopyToAsync(stream);
                }
            }

            _CIPlatformContext.Users.Add(user1);
            await _CIPlatformContext.SaveChangesAsync();

            return user;

        }

        public async Task<UserAdd> EditUserData(UserAdd user)
        {
            var user1 = _CIPlatformContext.Users.Where(u => u.UserId == user.UserId).FirstOrDefault();
            //User user1 = new User();
            if (user1 != null)
            {
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
                user1.UpdatedAt = DateTime.Now;
                user1.Department = user.Department;
                if (user.UserImg != null)
                {
                    user1.Avatar = user.UserImg.FileName;

                    var path = Path.Combine(Directory.GetCurrentDirectory(), "Images", user.UserImg.FileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await user.UserImg.CopyToAsync(stream);
                    }
                }

                _CIPlatformContext.Users.Update(user1);
                await _CIPlatformContext.SaveChangesAsync();
            }

            return user;
        }

        public async Task<bool> DeleteUserData(long UserId)
        {
            var user1 = _CIPlatformContext.Users.Where(u => u.UserId == UserId).FirstOrDefault();
            if (user1 != null)
            {
                user1.DeletedAt = DateTime.Now;
                _CIPlatformContext.Users.Update(user1);
                await _CIPlatformContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<User> GetUserData(long userId)
        {
            return await _CIPlatformContext.Users.FirstAsync(u => u.UserId == userId);
        }
        
        public async Task<User> LogInGetUserData(string email, string password)
        {
            User user = await _CIPlatformContext.Users.FirstAsync(u => u.Email == email && u.Password == password);
            return user;
        }

        public async Task<List<User>?> SearchUser(string? search, int page, int pageSize)
        {
            List<User> users = await _CIPlatformContext.Users.ToListAsync();
            int count = 0;
            if (search != null)
            {
                users = users.Where(b => (b.FirstName != null && b.FirstName.ToLower().Contains(search.ToLower())) || (b.LastName != null && b.LastName.ToLower().Contains(search.ToLower()))).ToList();
                count++;
            }
            if (page != 0 && pageSize != 0)
            {
                users = users.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                count++;
            }
            if (count > 0)
            {
                return users;
            }
            return null;
        }

    }
}
