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
    public class SearchUserQuery : IRequest<List<User>>
    {
        public SearchUserQuery(string? search, int page, int pageSize)
        {
            Search = search;
            Page = page;
            PageSize = pageSize;
        }

        public string? Search { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }

    public class SearchUserHandler : IRequestHandler<SearchUserQuery, List<User>>
    {
        private readonly IUserRepository _userRepository;

        public SearchUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<List<User>?> Handle(SearchUserQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.SearchUser(request.Search, request.Page, request.PageSize);
        }
    }
}
