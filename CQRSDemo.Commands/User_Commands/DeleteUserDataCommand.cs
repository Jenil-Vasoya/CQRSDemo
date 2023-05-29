using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDemo.Commands.User_Commands
{
    public class DeleteUserDataCommand : IRequest<bool>
    {
        public long  UserId { get; set; }
    }
}
