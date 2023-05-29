using CQRSDemo.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDemo.Commands.Theme_Commands
{
    public class AddThemeDataCommand : IRequest<MissionTheme>
    {
        public MissionTheme theme { get; set; }

        public AddThemeDataCommand(MissionTheme _theme)
        {
            theme = _theme;
        }
    }
}
