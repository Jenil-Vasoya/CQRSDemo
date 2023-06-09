﻿using CQRSDemo.Core.Models;
using CQRSDemo.Data.ViewModel;
using CQRSDemo.Repository.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDemo.Repository.Interface
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUser(Paging? dto);
        Task<User> GetUserData(long UserId);
        Task<long> AddUserData(UserAdd user);
        Task<UserAdd> EditUserData(UserAdd user);
        Task<bool> DeleteUserData(long UserId);
        Task<List<User>?> SearchUser(string? search, int page, int pageSize);

        Task<User> LogInGetUserData(string email, string password);
    }
}
