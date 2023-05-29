using CQRSDemo.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDemo.Commands.CMS_Commands
{
    public class AddCMSDataCommand : IRequest<Cmspage>
    {
        public Cmspage cms { get; set; }

        public AddCMSDataCommand(Cmspage _cms)
        {
            cms = _cms;
        }
    }
}
