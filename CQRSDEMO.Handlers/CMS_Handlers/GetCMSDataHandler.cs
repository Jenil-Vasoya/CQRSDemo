using CQRSDemo.Core.Models;
using CQRSDemo.Queries.CMS_Queries;
using CQRSDemo.Repository.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDEMO.Handlers.CMS_Handlers
{
    public class GetCMSDataHandler : IRequestHandler<GetCMSDataQuery, Cmspage>
    {
        private readonly ICMSRepository _cmsRepository;

        public GetCMSDataHandler(ICMSRepository cmsRepository)
        {
            _cmsRepository = cmsRepository;
        }
        public async Task<Cmspage> Handle(GetCMSDataQuery request, CancellationToken cancellationToken)
        {
            return await _cmsRepository.GetCMS(request.CMSId);
        }
    }
}
