using CQRSDemo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDemo.Repository.Interface
{
    public interface IStoryRepository
    {

        Task<bool> DeleteStoryData(long StoryId);

        Task<Story> EditStoryData(Story story);

        Task<List<Story>> GetAllStory();

        Task<Story> GetStory(long StoryId);

        Task<List<Story>?> SearchStory(string? search, int page, int pageSize);
    }
}
