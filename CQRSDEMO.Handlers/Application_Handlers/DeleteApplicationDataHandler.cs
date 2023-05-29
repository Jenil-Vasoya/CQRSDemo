using CQRSDemo.Commands.Application_Commands;
using CQRSDemo.Repository.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDEMO.Handlers.Application_Handlers
{
    public class DeleteApplicationDataHandler : IRequestHandler<DeleteApplicationDataCommand, bool>
    {
        private readonly IApplicationRepository _applicationRepository;

        public DeleteApplicationDataHandler(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        public async Task<bool> Handle(DeleteApplicationDataCommand request, CancellationToken cancellationToken)
        {
            return await _applicationRepository.DeleteApplicationData(request.ApplicationId);
        }
    }
}
