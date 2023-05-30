using CQRSDemo.Commands.Mission_Commands;
using System.ComponentModel.DataAnnotations.Schema;

namespace CQRSDemo.Controllers.DTOS
{
    public class MissionAdd
    {
        public long MissionId { get; set; }

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

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }


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

        //public AddMissionDataCommand ToMissionCommand()
        //{
        //    return new AddMissionDataCommand(MissionId, MissionThemeId, CityId, CountryId, Title ,ShortDescription ,Description ,StartDate ,EndDate ,MissionType ,Status ,OrganizationName ,OrganizationDetail ,TotalSeats ,GoalMissionId ,GoalText ,GoalValue ,CreatedAt ,UpdatedAt ,DeletedAt ,MissionSkill ,MissionImages ,VideoUrl ,Documents ,Availibility, Deadline);
        //}
    }
}
