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
    public class GetAllUserQuery : IRequest<List<User>>
    {
        public class Handler : IRequestHandler<GetAllUserQuery, List<User>>
        {
            private readonly IUserRepository _userRepository;

            public Handler(IUserRepository userRepository)
            {
                _userRepository = userRepository;
            }

            public async Task<List<User>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
            {
                return await _userRepository.GetAllUser();
            }
        }
    }


}
