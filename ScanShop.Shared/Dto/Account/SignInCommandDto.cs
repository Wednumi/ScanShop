using System.ComponentModel.DataAnnotations;

namespace ScanShop.Shared.Dto.Account
{
    public class SignInCommandDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "Minimum password length is 8")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
