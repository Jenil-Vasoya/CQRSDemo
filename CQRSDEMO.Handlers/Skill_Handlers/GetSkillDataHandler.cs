using CQRSDemo.Core.Models;
using CQRSDemo.Queries.CMS_Queries;
using CQRSDemo.Queries.Skill_Queries;
using CQRSDemo.Repository.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDEMO.Handlers.Skill_Handlers
{
    public class GetSkillDataHandler : IRequestHandler<GetSkillDataQuery, Skill>
    {
        private readonly ISkillRepository _skillRepository;

        public GetSkillDataHandler(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }
        public async Task<Skill> Handle(GetSkillDataQuery request, CancellationToken cancellationToken)
        {
            return await _skillRepository.GetSkill(request.SkillId);
        }
    }
}
