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
    public class ThemeRepository : IThemeRepository
    {
        private readonly CIPlatformContext _CIPlatformContext;

        public ThemeRepository(CIPlatformContext CIPlatformContext)
        {
            _CIPlatformContext = CIPlatformContext;
        }

        public async Task<List<MissionTheme>> GetAllTheme()
        {
            return await _CIPlatformContext.MissionThemes.ToListAsync();
        }

        public async Task<MissionTheme> GetTheme(long ThemeId)
        {
            return await _CIPlatformContext.MissionThemes.FirstAsync(c => c.MissionThemeId == ThemeId);
        }

        public async Task<MissionTheme> AddThemeData(MissionTheme theme)
        {
            _CIPlatformContext.MissionThemes.Add(theme);
            await _CIPlatformContext.SaveChangesAsync();
            return theme;
        }

        public async Task<MissionTheme> EditThemeData(MissionTheme theme)
        {
            MissionTheme missionTheme = await _CIPlatformContext.MissionThemes.FirstAsync(c => c.MissionThemeId == theme.MissionThemeId);
            if (missionTheme != null)
            {

                missionTheme.Titile = theme.Titile;
                missionTheme.Status = theme.Status;
                missionTheme.UpdatedAt = DateTime.Now;
                
                _CIPlatformContext.MissionThemes.Update(missionTheme);
                await _CIPlatformContext.SaveChangesAsync();
            }
            return theme;
        }

        public async Task<bool> DeleteThemeData(long ThemeId)
        {
            MissionTheme cmspage = await _CIPlatformContext.MissionThemes.FirstAsync(c => c.MissionThemeId == ThemeId);
            if (cmspage != null)
            {
                cmspage.DeletedAt = DateTime.Now;
                _CIPlatformContext.MissionThemes.Update(cmspage);
                await _CIPlatformContext.SaveChangesAsync();

                return true;
            }
            return false;
        }
    }
}
