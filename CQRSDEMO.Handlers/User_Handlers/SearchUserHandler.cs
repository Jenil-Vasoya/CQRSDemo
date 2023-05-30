using CQRSDemo.Core.Models;
using CQRSDemo.Queries.User_Queries;
using CQRSDemo.Repository.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDEMO.Handlers.Banner_Handlers
{
    public class SearchUserHandler : IRequestHandler<SearchUserQuery, List<User>>
    {
        private readonly IUserRepository _userRepository;

        public SearchUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<List<User>?> Handle(SearchUserQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.SearchUser(request.Search,request.Page,request.PageSize);
        }
    }
}
