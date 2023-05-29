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
    public class ApplicationRepository :IApplicationRepository
    {
        private readonly CIPlatformContext _CIPlatformContext;

        public ApplicationRepository(CIPlatformContext CIPlatformContext)
        {
            _CIPlatformContext = CIPlatformContext;
        }

        public async Task<List<MissionApplication>> GetAllApplication()
        {
            return await _CIPlatformContext.MissionApplications.ToListAsync();
        }

        public async Task<MissionApplication> GetApplication(long ApplicationId)
        {
            return await _CIPlatformContext.MissionApplications.FirstAsync(c => c.MissionApplicationId == ApplicationId);
        }

        public async Task<MissionApplication> EditApplicationData(MissionApplication application)
        {
            MissionApplication missionApplication = await _CIPlatformContext.MissionApplications.FirstAsync(c => c.MissionApplicationId == application.MissionApplicationId);
            if (missionApplication != null)
            {

                missionApplication.ApprovalStatus = application.ApprovalStatus;
                missionApplication.UpdatedAt = DateTime.Now;

                _CIPlatformContext.MissionApplications.Update(missionApplication);
                await _CIPlatformContext.SaveChangesAsync();
            }
            return application;
        }

        public async Task<bool> DeleteApplicationData(long ApplicationId)
        {
            MissionApplication cmspage = await _CIPlatformContext.MissionApplications.FirstAsync(c => c.MissionApplicationId == ApplicationId);
            if (cmspage != null)
            {
                cmspage.DeletedAt = DateTime.Now;
                _CIPlatformContext.MissionApplications.Update(cmspage);
                await _CIPlatformContext.SaveChangesAsync();

                return true;
            }
            return false;
        }
    }
}
