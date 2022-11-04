using System.ComponentModel.DataAnnotations;

namespace BLL.Models
{
    public class AuthenticateRequest
    {
        [Required]
        public string Username { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
    }
}
