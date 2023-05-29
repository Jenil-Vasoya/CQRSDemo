using CQRSDemo.Core.Models;
using CQRSDemo.Data.ViewModel;
using CQRSDemo.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDemo.Repository
{
    public class BannerRepository : IBannerRepository
    {
        private readonly CIPlatformContext _CIPlatformContext;

        public BannerRepository(CIPlatformContext CIPlatformContext)
        {
            _CIPlatformContext = CIPlatformContext;
        }

        public async Task<List<Banner>> GetAllBanner()
        {
            return await _CIPlatformContext.Banners.ToListAsync();
        }

        public async Task<Banner> AddBannerData(Banner banner)
        {
            
            if (banner.BannerImg != null)
            {
               
                var path = Path.Combine(Directory.GetCurrentDirectory(), "Images", banner.BannerImg.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await banner.BannerImg.CopyToAsync(stream);
                }
            }

            _CIPlatformContext.Banners.Add(banner);
            await _CIPlatformContext.SaveChangesAsync();

            return banner;

        }

        public async Task<Banner> EditBannerData(Banner banner)
        {
            Banner banner1 = await _CIPlatformContext.Banners.FirstAsync(c => c.BannerId == banner.BannerId);
            if (banner1 != null)
            {

                banner1.Text = banner.Text;
                banner1.SortOrder = banner.SortOrder;
                banner1.UpdatedAt = DateTime.Now;


            }
            if (banner.BannerImg != null)
            {
                banner1.Image = banner.BannerImg.FileName;

                var path = Path.Combine(Directory.GetCurrentDirectory(), "Images", banner.BannerImg.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await banner.BannerImg.CopyToAsync(stream);
                }
            }
            _CIPlatformContext.Banners.Update(banner1);
            await _CIPlatformContext.SaveChangesAsync();


            return banner;
        }

        public async Task<bool> DeleteBannerData(long BannerId)
        {
            var user1 = _CIPlatformContext.Banners.Where(u => u.BannerId == BannerId).FirstOrDefault();
            if (user1 != null)
            {
                user1.DeletedAt = DateTime.Now;
                _CIPlatformContext.Banners.Update(user1);
                await _CIPlatformContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Banner> GetBannerData(long bannerId)
        {
            return await _CIPlatformContext.Banners.FirstAsync(u => u.BannerId == bannerId);
        }

    }
}
