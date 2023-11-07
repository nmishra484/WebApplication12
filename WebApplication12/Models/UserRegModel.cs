using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication12.Models
{
    public class UserRegModel
    {
        [Required]
        [DisplayName("User ID")]
        public int id { get; set; }

        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        [Required]
        [DisplayName("Email ID")]
        public string emailid { get; set; }

        [Required]
        [DisplayName("User Password")]
        public string Password { get; set; }

        [Required]
        [DisplayName("User Name")]
        public string name { get; set; }
    }
} 