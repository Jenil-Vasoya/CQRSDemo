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
    public class GetAllBannerHandler : IRequestHandler<GetAllBannerQuery, List<Banner>>
    {
        private readonly IBannerRepository _bannerRepository;

        public GetAllBannerHandler(IBannerRepository bannerRepository)
        {
            _bannerRepository = bannerRepository;
        }
       
        public async Task<List<Banner>> Handle(GetAllBannerQuery query, CancellationToken cancellationToken)
        {
            return await _bannerRepository.GetAllBanner();
        }
    }
}
