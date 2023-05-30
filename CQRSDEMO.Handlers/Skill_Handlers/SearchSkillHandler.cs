using CQRSDemo.Core.Models;
using CQRSDemo.Queries.Skill_Queries;
using CQRSDemo.Repository.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDEMO.Handlers.Banner_Handlers
{
    public class SearchSkillHandler : IRequestHandler<SearchSkillQuery, List<Skill>>
    {
        private readonly ISkillRepository _skillRepository;

        public SearchSkillHandler(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }
        public async Task<List<Skill>?> Handle(SearchSkillQuery request, CancellationToken cancellationToken)
        {
            return await _skillRepository.SearchSkill(request.Search,request.Page,request.PageSize);
        }
    }
}
