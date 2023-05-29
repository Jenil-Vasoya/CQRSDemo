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
    public class GetAllCMSHandler : IRequestHandler<GetAllCMSQuery, List<Cmspage>>
    {
        private readonly ICMSRepository _cmsRepository;

        public GetAllCMSHandler(ICMSRepository cmsRepository)
        {
            _cmsRepository = cmsRepository;
        }
       
        public async Task<List<Cmspage>> Handle(GetAllCMSQuery query, CancellationToken cancellationToken)
        {
            return await _cmsRepository.GetAllCMS();
        }
    }
}
