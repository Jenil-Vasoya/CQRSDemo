using CQRSDemo.Commands.Skill_Commands;
using CQRSDemo.Repository.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDEMO.Handlers.Skill_Handlers
{
    public class DeleteSkillDataHandler : IRequestHandler<DeleteSkillDataCommand, bool>
    {
        private readonly ISkillRepository _skillRepository;

        public DeleteSkillDataHandler(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public async Task<bool> Handle(DeleteSkillDataCommand request, CancellationToken cancellationToken)
        {
            return await _skillRepository.DeleteSkillData(request.SkillId);
        }
    }
}