﻿using CQRSDemo.Core.Models;
using CQRSDemo.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDemo.Repository
{
    public class StoryRepository :IStoryRepository
    {
        private readonly CIPlatformContext _CIPlatformContext;

        public StoryRepository(CIPlatformContext CIPlatformContext)
        {
            _CIPlatformContext = CIPlatformContext;
        }

        public async Task<List<Story>> GetAllStory()
        {
            return await _CIPlatformContext.Stories.ToListAsync();
        }

        public async Task<Story> GetStory(long StoryId)
        {
            return await _CIPlatformContext.Stories.FirstAsync(c => c.StoryId == StoryId);
        }

        public async Task<Story> EditStoryData(Story story)
        {
            Story missionStory = await _CIPlatformContext.Stories.FirstAsync(c => c.StoryId == story.StoryId);
            if (missionStory != null)
            {

                missionStory.Status = story.Status;
                missionStory.UpdatedAt = DateTime.Now;

                _CIPlatformContext.Stories.Update(missionStory);
                await _CIPlatformContext.SaveChangesAsync();
            }
            return story;
        }

        public async Task<bool> DeleteStoryData(long StoryId)
        {
            Story cmspage = await _CIPlatformContext.Stories.FirstAsync(c => c.StoryId == StoryId);
            if (cmspage != null)
            {
                cmspage.DeletedAt = DateTime.Now;
                _CIPlatformContext.Stories.Update(cmspage);
                await _CIPlatformContext.SaveChangesAsync();

                return true;
            }
            return false;
        }

        public async Task<List<Story>?> SearchStory(string? search, int page, int pageSize)
        {
            List<Story> stories = await _CIPlatformContext.Stories.ToListAsync();
            int count = 0;
            if (search != null)
            {
                stories = stories.Where(b => b.Title.ToLower().Contains(search.ToLower())).ToList();
                count++;
            }
            if (page != 0 && pageSize != 0)
            {
                stories = stories.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                count++;
            }
            if (count > 0)
            {
                return stories;
            }
            return null;
        }
    }
}
