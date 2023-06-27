using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CQRSDemoFrontend.Models
{
    public partial class User
    {
        

        [Required(ErrorMessage = "Please enter the email")]
        [EmailAddress(ErrorMessage = "Please enter the valid email")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Please enter the password")]
        public string Password { get; set; } = null!;


        
       
    }
}
