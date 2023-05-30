using CQRSDemo.Core.Models;
using CQRSDemo.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDemo.Repository.Interface
{
    public interface IBannerRepository
    {
        Task<List<Banner>> GetAllBanner();
        Task<Banner> GetBannerData(long BannerId);
        Task<Banner> AddBannerData(Banner banner);
        Task<Banner> EditBannerData(Banner banner);
        Task<bool> DeleteBannerData(long BannerId);
        Task<List<Banner>?> SearchBanner(string? search, int page, int pageSize);
    }
}
