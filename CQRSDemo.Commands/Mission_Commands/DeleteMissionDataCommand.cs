using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDemo.Commands.Mission_Commands
{
    public class DeleteMissionDataCommand : IRequest<bool>
    {
        public long MissionId { get; set; }
    }
}
