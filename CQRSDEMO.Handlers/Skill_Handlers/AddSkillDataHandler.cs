using CQRSDemo.Commands.CMS_Commands;
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
    public class AddSkillDataHandler : IRequestHandler<AddSkillDataCommand, Skill>
    {
        private readonly ISkillRepository _skillRepository;

        public AddSkillDataHandler(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public async Task<Skill> Handle(AddSkillDataCommand request, CancellationToken cancellationToken)
        {
            return await _skillRepository.AddSkillData(request.skill);
        }
    }
}
