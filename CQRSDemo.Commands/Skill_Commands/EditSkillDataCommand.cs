using CQRSDemo.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDemo.Commands.Skill_Commands
{
    public class EditSkillDataCommand : IRequest<Skill>
    {
        public Skill skill { get; set; }

        public EditSkillDataCommand(Skill _skill)
        {
            skill = _skill;
        }
    }
}
