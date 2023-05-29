using CQRSDemo.Core.Models;
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
    public class GetAllSkillHandler : IRequestHandler<GetAllSkillQuery, List<Skill>>
    {
        private readonly ISkillRepository _skillRepository;

        public GetAllSkillHandler(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }
       
        public async Task<List<Skill>> Handle(GetAllSkillQuery query, CancellationToken cancellationToken)
        {
            return await _skillRepository.GetAllSkill();
        }
    }
}
