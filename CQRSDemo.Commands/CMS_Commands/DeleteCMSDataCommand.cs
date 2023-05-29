using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDemo.Commands.CMS_Commands
{
    public class DeleteCMSDataCommand : IRequest<bool>
    {
        public long CMSId { get; set; }
    }
}
