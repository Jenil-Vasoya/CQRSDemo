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
    public class GetMissionDataHandler : IRequestHandler<GetMissionDataQuery, Mission>
    {
        private readonly IMissionRepository _missionRepository;

        public GetMissionDataHandler(IMissionRepository missionRepository)
        {
            _missionRepository = missionRepository;
        }

        public async Task<Mission> Handle(GetMissionDataQuery request, CancellationToken cancellationToken)
        {
            return await _missionRepository.GetMissionData(request.MissionId);
        }
    }
}
