using CQRSDemo.Commands.Mission_Commands;
using CQRSDemo.Repository.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDEMO.Handlers.Mission_Handlers
{
    public class DeleteMissionDataHandler : IRequestHandler<DeleteMissionDataCommand, bool>
    {
        private readonly IMissionRepository _missionRepository;

        public DeleteMissionDataHandler(IMissionRepository missionRepository)
        {
            _missionRepository = missionRepository;
        }

        public async Task<bool> Handle(DeleteMissionDataCommand request, CancellationToken cancellationToken)
        {
            return await _missionRepository.DeleteMissionData(request.MissionId);
        }
    }
}
