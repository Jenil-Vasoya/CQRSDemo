using CQRSDemo.Commands.CMS_Commands;
using CQRSDemo.Commands.Banner_Commands;
using CQRSDemo.Core.Models;
using CQRSDemo.Repository.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDEMO.Handlers.Banner_Handlers
{
    public class AddBannerDataHandler : IRequestHandler<AddBannerDataCommand, Banner>
    {
        private readonly IBannerRepository _bannerRepository;

        public AddBannerDataHandler(IBannerRepository bannerRepository)
        {
            _bannerRepository = bannerRepository;
        }

        public async Task<Banner> Handle(AddBannerDataCommand request, CancellationToken cancellationToken)
        {
            return await _bannerRepository.AddBannerData(request.banner);
        }
    }
}
