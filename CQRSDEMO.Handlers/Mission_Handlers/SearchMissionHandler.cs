using CQRSDemo.Core.Models;
using CQRSDemo.Queries.Mission_Queries;
using CQRSDemo.Repository.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDEMO.Handlers.Banner_Handlers
{
    public class SearchMissionHandler : IRequestHandler<SearchMissionQuery, List<Mission>>
    {
        private readonly IMissionRepository _missionRepository;

        public SearchMissionHandler(IMissionRepository missionRepository)
        {
            _missionRepository = missionRepository;
        }
        public async Task<List<Mission>?> Handle(SearchMissionQuery request, CancellationToken cancellationToken)
        {
            return await _missionRepository.SearchMission(request.Search,request.Page,request.PageSize);
        }
    }
}
