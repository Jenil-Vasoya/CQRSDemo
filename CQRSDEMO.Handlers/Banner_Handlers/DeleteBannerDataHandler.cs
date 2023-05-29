using CQRSDemo.Commands.Banner_Commands;
using CQRSDemo.Repository.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDEMO.Handlers.Banner_Handlers
{
    public class DeleteBannerDataHandler : IRequestHandler<DeleteBannerDataCommand, bool>
    {
        private readonly IBannerRepository _bannerRepository;

        public DeleteBannerDataHandler(IBannerRepository bannerRepository)
        {
            _bannerRepository = bannerRepository;
        }

        public async Task<bool> Handle(DeleteBannerDataCommand request, CancellationToken cancellationToken)
        {
            return await _bannerRepository.DeleteBannerData(request.BannerId);
        }
    }
}