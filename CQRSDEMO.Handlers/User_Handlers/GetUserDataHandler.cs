using CQRSDemo.Core.Models;
using CQRSDemo.Queries.User_Queries;
using CQRSDemo.Repository.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDEMO.Handlers
{
    public class GetUserDataHandler : IRequestHandler<GetUserDataQuery, User>
    {
        private readonly IUserRepository _userRepository;

        public GetUserDataHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(GetUserDataQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetUserData(request.UserId);
        }
    }
}
