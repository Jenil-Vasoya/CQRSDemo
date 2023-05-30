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
    public class SearchApplicationHandler : IRequestHandler<SearchApplicationQuery, List<MissionApplication>>
    {
        private readonly IApplicationRepository _applicationRepository;

        public SearchApplicationHandler(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }
        public async Task<List<MissionApplication>?> Handle(SearchApplicationQuery request, CancellationToken cancellationToken)
        {
            return await _applicationRepository.SearchApplication(request.Search,request.Page,request.PageSize);
        }
    }
}
