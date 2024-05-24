using System.ComponentModel.DataAnnotations;

namespace Imtahan.ViewModels.account
{
    public class LoginVM
    {
        [Required]
        public string UsernameOrEmail { get; set; }

        [Required,DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string RememberMe { get; set; }
    }
}
