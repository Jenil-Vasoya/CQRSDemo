using CQRSDemo.Commands.CMS_Commands;
using CQRSDemo.Repository.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDEMO.Handlers.CMS_Handlers
{
    public class DeleteCMSDataHandler : IRequestHandler<DeleteCMSDataCommand, bool>
    {
        private readonly ICMSRepository _cmsRepository;

        public DeleteCMSDataHandler(ICMSRepository cmsRepository)
        {
            _cmsRepository = cmsRepository;
        }

        public async Task<bool> Handle(DeleteCMSDataCommand request, CancellationToken cancellationToken)
        {
            return await _cmsRepository.DeleteCMSData(request.CMSId);
        }
    }
}
