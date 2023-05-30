using CQRSDemo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDemo.Repository.Interface
{
    public interface IThemeRepository
    {
        Task<MissionTheme> AddThemeData(MissionTheme theme);

        Task<bool> DeleteThemeData(long ThemeId);

        Task<MissionTheme> EditThemeData(MissionTheme theme);

        Task<List<MissionTheme>> GetAllTheme();

        Task<MissionTheme> GetTheme(long ThemeId);

        Task<List<MissionTheme>?> SearchTheme(string? search, int page, int pageSize);
    }
}
