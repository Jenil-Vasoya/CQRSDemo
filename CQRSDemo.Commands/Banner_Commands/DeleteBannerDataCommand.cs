using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDemo.Commands.Banner_Commands
{
    public class DeleteBannerDataCommand : IRequest<bool>
    {
        public long BannerId { get; set; }
    }
}
