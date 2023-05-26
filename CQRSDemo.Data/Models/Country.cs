using System;
using System.Collections.Generic;

namespace CQRSDemo.Core.Models
{
    public partial class Country
    {
        public Country()
        {
            Cities = new HashSet<City>();
            Missions = new HashSet<Mission>();
            Users = new HashSet<User>();
        }

        public long CountryId { get; set; }
        public string CountryName { get; set; } = null!;
        public string? Iso { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<Mission> Missions { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
