using CQRSDemo.Queries.Application_Queries;
using CQRSDemo.Queries.Banner_Queries;
using CQRSDemo.Queries.CMS_Queries;
using CQRSDemo.Queries.Mission_Queries;
using CQRSDemo.Queries.Skill_Queries;
using CQRSDemo.Queries.Story_Queries;
using CQRSDemo.Queries.Theme_Queries;
using CQRSDemo.Queries.User_Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDemo.Data.ViewModel
{
    public class Pagination
    {
        public string? Search { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }

        public SearchBannerQuery ToBannerQuery()
        {
            return new SearchBannerQuery(Search,Page,PageSize);
        }
        
        public SearchApplicationQuery ToApplicationQuery()
        {
            return new SearchApplicationQuery(Search,Page,PageSize);
        }
        
        public SearchCMSQuery ToCMSQuery()
        {
            return new SearchCMSQuery(Search,Page,PageSize);
        }
        
        public SearchMissionQuery ToMissionQuery()
        {
            return new SearchMissionQuery(Search,Page,PageSize);
        }
        public SearchSkillQuery ToSkillQuery()
        {
            return new SearchSkillQuery(Search,Page,PageSize);
        }
        
        public SearchStoryQuery ToStoryQuery()
        {
            return new SearchStoryQuery(Search,Page,PageSize);
        }
        
        public SearchThemeQuery ToThemeQuery()
        {
            return new SearchThemeQuery(Search,Page,PageSize);
        }
        
        public SearchUserQuery ToUserQuery()
        {
            return new SearchUserQuery(Search,Page,PageSize);
        }


    }
}
