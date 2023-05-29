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
        public Task<List<Banner>> GetAllBanner();

        public Task<Banner> GetBannerData(long BannerId);
        public Task<Banner> AddBannerData(Banner banner);

        public Task<Banner> EditBannerData(Banner banner);

        public Task<bool> DeleteBannerData(long BannerId);
    }
}
