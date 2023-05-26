using System;
using System.Collections.Generic;

namespace CQRSDemo.Core.Models
{
    public partial class Story
    {
        public Story()
        {
            Notifications = new HashSet<Notification>();
            StoryInvites = new HashSet<StoryInvite>();
            StoryMedia = new HashSet<StoryMedium>();
            StoryViews = new HashSet<StoryView>();
        }

        public long StoryId { get; set; }
        public long UserId { get; set; }
        public long MissionId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string Status { get; set; } = null!;
        public DateTime? PublishedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public long Views { get; set; }

        public virtual Mission Mission { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<StoryInvite> StoryInvites { get; set; }
        public virtual ICollection<StoryMedium> StoryMedia { get; set; }
        public virtual ICollection<StoryView> StoryViews { get; set; }
    }
}
