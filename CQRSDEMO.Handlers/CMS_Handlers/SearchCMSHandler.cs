using CQRSDemo.Core.Models;
using CQRSDemo.Queries.CMS_Queries;
using CQRSDemo.Repository.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDEMO.Handlers.Banner_Handlers
{
    public class SearchCMSHandler : IRequestHandler<SearchCMSQuery, List<Cmspage>>
    {
        private readonly ICMSRepository _bannerRepository;

        public SearchCMSHandler(ICMSRepository bannerRepository)
        {
            _bannerRepository = bannerRepository;
        }
        public async Task<List<Cmspage>?> Handle(SearchCMSQuery request, CancellationToken cancellationToken)
        {
            return await _bannerRepository.SearchCMS(request.Search,request.Page,request.PageSize);
        }
    }
}
