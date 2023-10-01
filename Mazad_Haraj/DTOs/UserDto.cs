using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mazad_Haraj.DTOs
{
    public class UserDto
    {

        public int Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }

        [NotMapped]
        public IFormFile? Image { get; set; }
        public string City { get; set; }
        public string Bio { get; set; }
        public string Type { get; set; }

        [Required(ErrorMessage = "Password is required, Please Enter a"), DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Email must be less than {0}")]
        public string Password { set; get; }

        [Required(ErrorMessage = "Confirm Password is required, Please Enter a"), DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Email must be less than {0}")]
        [Compare(nameof(Password), ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { set; get; }

        public string IdNumber { get; set; }
        public string IdPhoto { get; set; }
        public string BankNumber { get; set; }
        public string WhatsAppNumber { get; set; }
    }
}
