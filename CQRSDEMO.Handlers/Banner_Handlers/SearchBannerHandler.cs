using CQRSDemo.Core.Models;
using CQRSDemo.Queries.Banner_Queries;
using CQRSDemo.Repository.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDEMO.Handlers.Banner_Handlers
{
    public class SearchBannerHandler : IRequestHandler<SearchBannerQuery, List<Banner>>
    {
        private readonly IBannerRepository _bannerRepository;

        public SearchBannerHandler(IBannerRepository bannerRepository)
        {
            _bannerRepository = bannerRepository;
        }
        public async Task<List<Banner>> Handle(SearchBannerQuery request, CancellationToken cancellationToken)
        {
            return await _bannerRepository.SearchBanner(request.Search,request.Page,request.PageSize);
        }
    }
}
