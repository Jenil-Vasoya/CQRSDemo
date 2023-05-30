using CQRSDemo.Data.ViewModel;
using System;
using System.Collections.Generic;

namespace CQRSDemo.Core.Models
{
    public partial class Mission
    {
        public Mission()
        {
            Comments = new HashSet<Comment>();
            FavoriteMissions = new HashSet<FavoriteMission>();
            GoalMissions = new HashSet<GoalMission>();
            MissionApplications = new HashSet<MissionApplication>();
            MissionDocuments = new HashSet<MissionDocument>();
            MissionInvites = new HashSet<MissionInvite>();
            MissionMedia = new HashSet<MissionMedium>();
            MissionRatings = new HashSet<MissionRating>();
            MissionSkills = new HashSet<MissionSkill>();
            Notifications = new HashSet<Notification>();
            Stories = new HashSet<Story>();
            TimeSheets = new HashSet<TimeSheet>();
        }

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
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string? Availibility { get; set; }
        public DateTime? Deadline { get; set; }

        public virtual City City { get; set; } = null!;
        public virtual Country Country { get; set; } = null!;
        public virtual MissionTheme MissionTheme { get; set; } = null!;
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<FavoriteMission> FavoriteMissions { get; set; }
        public virtual ICollection<GoalMission> GoalMissions { get; set; }
        public virtual ICollection<MissionApplication> MissionApplications { get; set; }
        public virtual ICollection<MissionDocument> MissionDocuments { get; set; }
        public virtual ICollection<MissionInvite> MissionInvites { get; set; }
        public virtual ICollection<MissionMedium> MissionMedia { get; set; }
        public virtual ICollection<MissionRating> MissionRatings { get; set; }
        public virtual ICollection<MissionSkill> MissionSkills { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<Story> Stories { get; set; }
        public virtual ICollection<TimeSheet> TimeSheets { get; set; }

        public static implicit operator Mission(MissionAddModel v)
        {
            throw new NotImplementedException();
        }
    }
}
