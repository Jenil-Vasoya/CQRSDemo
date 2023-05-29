using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDemo.Commands.Theme_Commands
{
    public class DeleteThemeDataCommand : IRequest<bool>
    {
        public long ThemeId { get; set; }
    }
}
