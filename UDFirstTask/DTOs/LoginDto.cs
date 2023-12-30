using System.ComponentModel.DataAnnotations;

namespace UDFirstTask.DTOs
{
    public class LoginDto
    {
        [Required(ErrorMessage = "The UserName field is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "The UserName must be between 2 and 100 characters.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "The Password field is required.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "The Password must be between 2 and 50 characters.")]
        public string Password { get; set; }
    }
}
