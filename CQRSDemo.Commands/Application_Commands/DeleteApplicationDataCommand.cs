using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDemo.Commands.Application_Commands
{
    public class DeleteApplicationDataCommand : IRequest<bool>
    {
        public long ApplicationId { get; set; }
    }
}
