using CQRSDemo.Core.Models;
using CQRSDemo.Queries.Application_Queries;
using CQRSDemo.Repository.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDEMO.Handlers.Application_Handlers
{
    public class GetAllApplicationHandler : IRequestHandler<GetAllApplicationQuery, List<MissionApplication>>
    {
        private readonly IApplicationRepository _skillRepository;

        public GetAllApplicationHandler(IApplicationRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }
       
        public async Task<List<MissionApplication>> Handle(GetAllApplicationQuery query, CancellationToken cancellationToken)
        {
            return await _skillRepository.GetAllApplication();
        }
    }
}
