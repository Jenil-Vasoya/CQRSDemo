using CQRSDemo.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDemo.Commands.Theme_Commands
{
    public class EditThemeDataCommand : IRequest<MissionTheme>
    {
        public MissionTheme theme { get; set; }

        public EditThemeDataCommand(MissionTheme _theme)
        {
            theme = _theme;
        }
    }
}
