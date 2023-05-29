using CQRSDemo.Commands.Application_Commands;
using CQRSDemo.Core.Models;
using CQRSDemo.Repository.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDEMO.Handlers.Application_Handlers
{
    public class EditApplicationDataHandler : IRequestHandler<EditApplicationDataCommand, MissionApplication>
    {
        private readonly IApplicationRepository _applicationRepository;

        public EditApplicationDataHandler(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        public async Task<MissionApplication> Handle(EditApplicationDataCommand request, CancellationToken cancellationToken)
        {
           return await _applicationRepository.EditApplicationData(request.application);
        }
    }
}
