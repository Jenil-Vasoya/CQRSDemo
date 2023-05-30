using CQRSDemo.Queries.Application_Queries;
using CQRSDemo.Queries.Banner_Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDemo.Data.ViewModel
{
    public class Pagination
    {
        public string? Search { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }

        public SearchBannerQuery ToBannerQuery()
        {
            return new SearchBannerQuery(Search,Page,PageSize);
        }
        
        public SearchApplicationQuery ToApplicationQuery()
        {
            return new SearchApplicationQuery(Search,Page,PageSize);
        }
    }
}
