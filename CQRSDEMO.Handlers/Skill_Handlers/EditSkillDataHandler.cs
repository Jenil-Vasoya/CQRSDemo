using CQRSDemo.Commands.Skill_Commands;
using CQRSDemo.Core.Models;
using CQRSDemo.Repository.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDEMO.Handlers.Skill_Handlers
{
    public class EditSkillDataHandler : IRequestHandler<EditSkillDataCommand, Skill>
    {
        private readonly ISkillRepository _skillRepository;

        public EditSkillDataHandler(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public async Task<Skill> Handle(EditSkillDataCommand request, CancellationToken cancellationToken)
        {
           return await _skillRepository.EditSkillData(request.skill);
        }
    }
}
