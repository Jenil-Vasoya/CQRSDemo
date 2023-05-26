using System;
using System.Collections.Generic;

namespace CQRSDemo.Core.Models
{
    public partial class User
    {
        public User()
        {
            Comments = new HashSet<Comment>();
            ContactUs = new HashSet<ContactU>();
            FavoriteMissions = new HashSet<FavoriteMission>();
            MissionApplications = new HashSet<MissionApplication>();
            MissionInvites = new HashSet<MissionInvite>();
            MissionRatings = new HashSet<MissionRating>();
            NotificationSettings = new HashSet<NotificationSetting>();
            Notifications = new HashSet<Notification>();
            Stories = new HashSet<Story>();
            StoryViews = new HashSet<StoryView>();
            TimeSheets = new HashSet<TimeSheet>();
            UserSkills = new HashSet<UserSkill>();
        }

        public long UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int PhoneNumber { get; set; }
        public string? Avatar { get; set; }
        public string? WhyIvolunteer { get; set; }
        public string? EmployeeId { get; set; }
        public string? Department { get; set; }
        public long? CityId { get; set; }
        public long? CountryId { get; set; }
        public string? ProfileText { get; set; }
        public string? LinkedInUrl { get; set; }
        public string? Title { get; set; }
        public bool? Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string Role { get; set; } = null!;

        public virtual City? City { get; set; }
        public virtual Country? Country { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<ContactU> ContactUs { get; set; }
        public virtual ICollection<FavoriteMission> FavoriteMissions { get; set; }
        public virtual ICollection<MissionApplication> MissionApplications { get; set; }
        public virtual ICollection<MissionInvite> MissionInvites { get; set; }
        public virtual ICollection<MissionRating> MissionRatings { get; set; }
        public virtual ICollection<NotificationSetting> NotificationSettings { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<Story> Stories { get; set; }
        public virtual ICollection<StoryView> StoryViews { get; set; }
        public virtual ICollection<TimeSheet> TimeSheets { get; set; }
        public virtual ICollection<UserSkill> UserSkills { get; set; }
    }
}
