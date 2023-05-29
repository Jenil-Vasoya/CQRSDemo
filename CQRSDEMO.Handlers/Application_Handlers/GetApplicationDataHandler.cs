using CQRSDemo.Core.Models;
using CQRSDemo.Queries.CMS_Queries;
using CQRSDemo.Queries.Application_Queries;
using CQRSDemo.Repository.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQRSDemo.Queries.Application_Queries;

namespace CQRSDEMO.Handlers.Application_Handlers
{
    public class GetApplicationDataHandler : IRequestHandler<GetApplicationDataQuery, MissionApplication>
    {
        private readonly IApplicationRepository _applicationRepository;

        public GetApplicationDataHandler(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }
        public async Task<MissionApplication> Handle(GetApplicationDataQuery request, CancellationToken cancellationToken)
        {
            return await _applicationRepository.GetApplication(request.ApplicationId);
        }
    }
}
