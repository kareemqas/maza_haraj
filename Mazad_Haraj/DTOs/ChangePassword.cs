using System.ComponentModel.DataAnnotations;

namespace Mazad_Haraj.DTO
{
    public class ChangePassword
    {

        [Required(ErrorMessage = " Currnet Password is Requierd , please check")]
        [DataType(DataType.Password)]
        public string CurrnetPassword { get; set; }


        [Required(ErrorMessage = "Password is Requierd , please check")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = " Confirm Password is Requierd , please check")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }


    }
}

