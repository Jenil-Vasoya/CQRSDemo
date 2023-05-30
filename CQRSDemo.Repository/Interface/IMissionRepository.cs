using CQRSDemo.Core.Models;
using CQRSDemo.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDemo.Repository.Interface
{
    public interface IMissionRepository
    {
        Task<List<Mission>> GetAllMission();
        Task<Mission> GetMissionData(long MissionId);
        Task<bool> DeleteMissionData(long MissionId);
        Task<List<Mission>?> SearchMission(string? search, int page, int pageSize);
        Task<MissionAddModel> AddMissionData(MissionAddModel model);
    }
}
