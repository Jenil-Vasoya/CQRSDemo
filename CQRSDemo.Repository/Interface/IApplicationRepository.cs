using CQRSDemo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDemo.Repository.Interface
{
    public interface IApplicationRepository
    {

        Task<bool> DeleteApplicationData(long ApplicationId);

        Task<MissionApplication> EditApplicationData(MissionApplication application);

        Task<List<MissionApplication>> GetAllApplication();

        Task<MissionApplication> GetApplication(long ApplicationId);

        Task<List<MissionApplication>?> SearchApplication(string? search, int page, int pageSize);
    }
}
