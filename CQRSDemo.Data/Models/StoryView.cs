using System;
using System.Collections.Generic;

namespace CQRSDemo.Core.Models
{
    public partial class StoryView
    {
        public long ViewId { get; set; }
        public long StoryId { get; set; }
        public long UserId { get; set; }

        public virtual Story Story { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
