using CQRSDemo.Core.Models;
using CQRSDemo.Data.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDemo.Commands.Mission_Commands
{
    public class AddMissionDataCommand : IRequest<MissionAddModel>
    {
       public MissionAddModel mission { get; set; }
       public AddMissionDataCommand(MissionAddModel _mission)
        {
            mission = _mission;
        }

    }
}
