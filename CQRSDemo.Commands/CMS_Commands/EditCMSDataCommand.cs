using CQRSDemo.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDemo.Commands.CMS_Commands
{
    public class EditCMSDataCommand : IRequest<Cmspage>
    {
        public Cmspage cmspage { get; set; }

        public EditCMSDataCommand(Cmspage _cmspage)
        {
            cmspage = _cmspage;
        }
    }
}
