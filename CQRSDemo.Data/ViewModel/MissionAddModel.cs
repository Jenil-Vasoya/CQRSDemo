
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDemo.Data.ViewModel
{
    public class MissionAddModel
    {
        public long? MissionId { get; set; }

        public long MissionThemeId { get; set; }

        public long CityId { get; set; }

        public long CountryId { get; set; }

        public string Title { get; set; } = null!;

        public string? ShortDescription { get; set; }

        public string? Description { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }


        public string? MissionType { get; set; }

        public bool? Status { get; set; }

        public string? OrganizationName { get; set; }

        public string? OrganizationDetail { get; set; }

        public int? TotalSeats { get; set; }

        [NotMapped]
        public long? GoalMissionId { get; set; }

        [NotMapped]
        public string? GoalText { get; set; }

        [NotMapped]
        public int GoalValue { get; set; }



        [NotMapped]
        public List<int>? MissionSkill { get; set; }

        [NotMapped]
        public List<IFormFile>? MissionImages { get; set; }


        [NotMapped]
        public string? VideoUrl { get; set; }


        [NotMapped]
        public List<IFormFile>? Documents { get; set; }

        public string? Availibility { get; set; }

        public DateTime? Deadline { get; set; }
    }
}
