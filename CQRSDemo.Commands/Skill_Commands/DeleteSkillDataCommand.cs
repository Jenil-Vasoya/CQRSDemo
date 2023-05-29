using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDemo.Commands.Skill_Commands
{
    public class DeleteSkillDataCommand : IRequest<bool>
    {
        public long SkillId { get; set; }
    }
}
