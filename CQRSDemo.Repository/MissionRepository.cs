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
    public class MissionRepository : IMissionRepository
    {

        private readonly CIPlatformContext _CIPlatformContext;

        public MissionRepository(CIPlatformContext CIPlatformContext)
        {
            _CIPlatformContext = CIPlatformContext;
        }

        public async Task<List<Mission>> GetAllMission()
        {
            return await _CIPlatformContext.Missions.ToListAsync();
        }

        public async Task<Mission> GetMissionData(long MissionId)
        {
            var mission = await _CIPlatformContext.Missions.FirstOrDefaultAsync(m => m.MissionId == MissionId);
            return mission;
        }

        public async Task<bool> DeleteMissionData(long MissionId)
        {
            var mission = _CIPlatformContext.Missions.Where(u => u.MissionId == MissionId).FirstOrDefault();
            if (mission != null)
            {
                mission.DeletedAt = DateTime.Now;
                 _CIPlatformContext.Missions.Update(mission);
                await _CIPlatformContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
