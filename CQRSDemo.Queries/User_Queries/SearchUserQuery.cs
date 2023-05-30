using CQRSDemo.Core.Models;
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
}
