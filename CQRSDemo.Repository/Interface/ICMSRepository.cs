using CQRSDemo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDemo.Repository.Interface
{
    public interface ICMSRepository
    {
        Task<Cmspage> AddCMSData(Cmspage cms);

        Task<bool> DeleteCMSData(long CMSId);

        Task<Cmspage> EditCMSData(Cmspage cms);

        Task<List<Cmspage>> GetAllCMS();

        Task<Cmspage> GetCMS(long CMSId);
    }
}
