using CQRSDemo.Commands.CMS_Commands;
using CQRSDemo.Core.Models;
using CQRSDemo.Repository.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDEMO.Handlers.CMS_Handlers
{
    public class EditCMSDataHandler : IRequestHandler<EditCMSDataCommand, Cmspage>
    {
        private readonly ICMSRepository _cmsRepository;

        public EditCMSDataHandler(ICMSRepository cmsRepository)
        {
            _cmsRepository = cmsRepository;
        }

        public async Task<Cmspage> Handle(EditCMSDataCommand request, CancellationToken cancellationToken)
        {
           return await _cmsRepository.EditCMSData(request.cmspage);
        }
    }
}
