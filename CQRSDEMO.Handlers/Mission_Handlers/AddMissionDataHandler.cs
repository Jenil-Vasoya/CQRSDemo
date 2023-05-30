using CQRSDemo.Commands;
using CQRSDemo.Commands.Mission_Commands;
using CQRSDemo.Core.Models;
using CQRSDemo.Data.ViewModel;
using CQRSDemo.Repository.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDEMO.Handlers
{
    public class AddMissionDataHandler : IRequestHandler<AddMissionDataCommand, MissionAddModel>
    {

        private readonly IMissionRepository _missionRepository;

        public AddMissionDataHandler(IMissionRepository missionRepository)
        {
            _missionRepository = missionRepository;
        }


        public async Task<MissionAddModel> Handle(AddMissionDataCommand query, CancellationToken cancellationToken)
        {
            return await _missionRepository.AddMissionData(query.mission);
        }
    }
}
