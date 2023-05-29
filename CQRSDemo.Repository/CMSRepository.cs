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
    public class CMSRepository : ICMSRepository
    {
        private readonly CIPlatformContext _CIPlatformContext;

        public CMSRepository(CIPlatformContext CIPlatformContext)
        {
            _CIPlatformContext = CIPlatformContext;
        }

        public async Task<List<Cmspage>> GetAllCMS()
        {
            return await _CIPlatformContext.Cmspages.ToListAsync();
        }

        public async Task<Cmspage> GetCMS(long CMSId)
        {
            return await _CIPlatformContext.Cmspages.FirstAsync(c=> c.CmspageId == CMSId);
        }

        public async Task<Cmspage> AddCMSData(Cmspage cms)
        {
            _CIPlatformContext.Cmspages.Add(cms);
            await _CIPlatformContext.SaveChangesAsync();
            return cms;
        }

        public async Task<Cmspage> EditCMSData(Cmspage cms)
        {
            Cmspage cmsPage = await _CIPlatformContext.Cmspages.FirstAsync(c=> c.CmspageId == cms.CmspageId);
            if(cmsPage != null)
            {
                
                cmsPage.Title = cms.Title;
                cmsPage.Description = cms.Description;
                cmsPage.Slug = cms.Slug;
                cmsPage.Status = cms.Status;
                cmsPage.UpdatedAt = DateTime.Now;
                _CIPlatformContext.Cmspages.Update(cmsPage);
                await _CIPlatformContext.SaveChangesAsync();
            }
            return cms;
        }

        public async Task<bool> DeleteCMSData(long CMSId)
        {
            Cmspage cmspage = await _CIPlatformContext.Cmspages.FirstAsync(c=> c.CmspageId == CMSId);
            if(cmspage != null)
            {
                cmspage.DeletedAt = DateTime.Now;
                _CIPlatformContext.Cmspages.Update(cmspage);
                await _CIPlatformContext.SaveChangesAsync();

                return true;
            }
            return false;
        }
    }
}
