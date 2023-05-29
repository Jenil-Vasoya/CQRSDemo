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
    public class EditBannerDataHandler : IRequestHandler<EditBannerDataCommand, Banner>
    {
        private readonly IBannerRepository _bannerRepository;

        public EditBannerDataHandler(IBannerRepository bannerRepository)
        {
            _bannerRepository = bannerRepository;
        }

        public async Task<Banner> Handle(EditBannerDataCommand request, CancellationToken cancellationToken)
        {
           return await _bannerRepository.EditBannerData(request.Banner);
        }
    }
}
