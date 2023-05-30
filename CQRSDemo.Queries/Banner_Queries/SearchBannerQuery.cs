using CQRSDemo.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDemo.Queries.Banner_Queries
{
    public class SearchBannerQuery : IRequest<List<Banner>>
    {
        public SearchBannerQuery(string? search, int page, int pageSize)
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
