using System.ComponentModel.DataAnnotations;

namespace Cibertec.MVC.Models
{
    public class UserViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string ReturnURL { get; set; }
    }
}