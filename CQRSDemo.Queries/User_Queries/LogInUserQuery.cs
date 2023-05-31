using CQRSDemo.Core.Models;
using CQRSDemo.Repository.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDemo.Queries.User_Queries
{
    public class LogInUserQuery : IRequest<User>
    {
        public string email { get; set; }
        public string password { get; set; }
    }
    public class LogInUserHandler : IRequestHandler<LogInUserQuery, User>
    {
        private readonly IUserRepository _userRepository;

        public LogInUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(LogInUserQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.LogInGetUserData(request.email,request.password);
        }
    }
}
