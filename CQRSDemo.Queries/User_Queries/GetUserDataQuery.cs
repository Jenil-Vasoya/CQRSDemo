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
    public class GetUserDataQuery : IRequest<User>
    {
        public long UserId { get; set; }
    }

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
