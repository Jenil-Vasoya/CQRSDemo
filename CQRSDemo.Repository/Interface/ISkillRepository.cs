using CQRSDemo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDemo.Repository.Interface
{
    public interface ISkillRepository
    {
        Task<Skill> AddSkillData(Skill skill);

        Task<bool> DeleteSkillData(long SkillId);

        Task<Skill> EditSkillData(Skill skill);

        Task<List<Skill>> GetAllSkill();

        Task<Skill> GetSkill(long SkillId);

        Task<List<Skill>?> SearchSkill(string? search, int page, int pageSize);
    }
}
