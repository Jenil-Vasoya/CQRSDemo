using CQRSDemo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDemo.Repository.Interface
{
    public interface IMissionRepository
    {
        public Task<List<Mission>> GetAllMission();

        public Task<Mission> GetMissionData(long MissionId);

        public Task<bool> DeleteMissionData(long MissionId);
    }
}
