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
    public class GetAllUserHandler : IRequestHandler<GetAllUserQuery, List<User>>
    {
        
         private readonly IUserRepository _userRepository;

        public GetAllUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
    

        public async Task<List<User>> Handle(GetAllUserQuery query, CancellationToken cancellationToken)
        {
            return await _userRepository.GetAllUser();
        }
    }
}
