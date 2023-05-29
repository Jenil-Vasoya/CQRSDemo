using CQRSDemo.Core.Models;
using CQRSDemo.Queries.Mission_Queries;
using CQRSDemo.Repository.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDEMO.Handlers.Mission_Handlers
{
    public class GetAllMissionHandler : IRequestHandler<GetAllMissionQuery, List<Mission>>
    {
        private readonly IMissionRepository _missionRepository;

        public GetAllMissionHandler(IMissionRepository missionRepository)
        {
            _missionRepository = missionRepository;
        }

        public async Task<List<Mission>> Handle(GetAllMissionQuery request, CancellationToken cancellationToken)
        {
            return await _missionRepository.GetAllMission();
        }
    }
}
