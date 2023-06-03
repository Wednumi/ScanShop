using System.ComponentModel.DataAnnotations;

namespace ScanShop.Shared.Dto.Account
{
    public class SignUpCommandDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "Minimum password length is 8")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm password")]
        [MinLength(8, ErrorMessage = "Minimum password length is 8")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
