using CQRSDemo.Core.Models;
using CQRSDemo.Queries.CMS_Queries;
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
    public class GetBannerDataHandler : IRequestHandler<GetBannerDataQuery, Banner>
    {
        private readonly IBannerRepository _bannerRepository;

        public GetBannerDataHandler(IBannerRepository bannerRepository)
        {
            _bannerRepository = bannerRepository;
        }
        public async Task<Banner> Handle(GetBannerDataQuery request, CancellationToken cancellationToken)
        {
            return await _bannerRepository.GetBannerData(request.BannerId);
        }
    }
}
