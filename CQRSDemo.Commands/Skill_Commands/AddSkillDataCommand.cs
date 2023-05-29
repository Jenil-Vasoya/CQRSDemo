using CQRSDemo.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDemo.Commands.Skill_Commands
{
    public class AddSkillDataCommand : IRequest<Skill>
    {
        public Skill skill { get; set; }

        public AddSkillDataCommand(Skill _skill)
        {
            skill = _skill;
        }
    }
}
