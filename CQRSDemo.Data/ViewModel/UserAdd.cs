using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDemo.Data.ViewModel
{
    public class UserAdd
    {
        public long? UserId { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? EmployeeId { get; set; }
        public string? Department { get; set; }
        public long? CityId { get; set; }
        public long? CountryId { get; set; }
        public bool? Status { get; set; }
        public string Role { get; set; } = null!;
        public string? ProfileText { get; set; }

        public IFormFile? UserImg { get; set; }
    }
}
