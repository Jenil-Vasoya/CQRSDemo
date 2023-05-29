using CQRSDemo.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDemo.Commands.Banner_Commands
{
    public class AddBannerDataCommand : IRequest<Banner>
    {
        public Banner banner { get; set; }

        public AddBannerDataCommand(Banner _banner)
        {
            banner = _banner;
        }
    }
}
