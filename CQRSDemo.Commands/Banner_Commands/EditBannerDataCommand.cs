using CQRSDemo.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDemo.Commands.Banner_Commands
{
    public class EditBannerDataCommand : IRequest<Banner>
    {
        public Banner Banner { get; set; }

        public EditBannerDataCommand(Banner _Banner)
        {
            Banner = _Banner;
        }
    }
}
