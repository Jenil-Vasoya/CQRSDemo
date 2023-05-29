using CQRSDemo.Core.Models;
using CQRSDemo.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDemo.Repository
{
    public class SkillRepository :ISkillRepository
    {
        private readonly CIPlatformContext _CIPlatformContext;

        public SkillRepository(CIPlatformContext CIPlatformContext)
        {
            _CIPlatformContext = CIPlatformContext;
        }

        public async Task<List<Skill>> GetAllSkill()
        {
            return await _CIPlatformContext.Skills.ToListAsync();
        }

        public async Task<Skill> GetSkill(long SkillId)
        {
            return await _CIPlatformContext.Skills.FirstAsync(c => c.SkillId == SkillId);
        }

        public async Task<Skill> AddSkillData(Skill skill)
        {
            _CIPlatformContext.Skills.Add(skill);
            await _CIPlatformContext.SaveChangesAsync();
            return skill;
        }

        public async Task<Skill> EditSkillData(Skill skill)
        {
            Skill missionSkill = await _CIPlatformContext.Skills.FirstAsync(c => c.SkillId == skill.SkillId);
            if (missionSkill != null)
            {

                missionSkill.SkillName = skill.SkillName;
                missionSkill.Status = skill.Status;
                missionSkill.UpdatedAt = DateTime.Now;

                _CIPlatformContext.Skills.Update(missionSkill);
                await _CIPlatformContext.SaveChangesAsync();
            }
            return skill;
        }

        public async Task<bool> DeleteSkillData(long SkillId)
        {
            Skill cmspage = await _CIPlatformContext.Skills.FirstAsync(c => c.SkillId == SkillId);
            if (cmspage != null)
            {
                cmspage.DeletedAt = DateTime.Now;
                _CIPlatformContext.Skills.Update(cmspage);
                await _CIPlatformContext.SaveChangesAsync();

                return true;
            }
            return false;
        }
    }
}
