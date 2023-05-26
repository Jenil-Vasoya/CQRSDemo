using System;
using System.Collections.Generic;

namespace CQRSDemo.Core.Models
{
    public partial class NotificationSetting
    {
        public long NotificationSettingId { get; set; }
        public long? UserId { get; set; }
        public string? Type { get; set; }

        public virtual User? User { get; set; }
    }
}
