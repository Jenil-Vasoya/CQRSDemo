using CQRSDemo.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDemo.Commands.Application_Commands
{
    public class EditApplicationDataCommand : IRequest<MissionApplication>
    {
        public MissionApplication application { get; set; }

        public EditApplicationDataCommand(MissionApplication _application)
        {
            application = _application;
        }
    }
}
