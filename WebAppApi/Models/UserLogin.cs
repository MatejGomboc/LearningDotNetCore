using System.ComponentModel.DataAnnotations;

namespace WebAppApi.Models
{
    public class UserLogin
    {
        [Required]
        [MaxLength(128)]
        public string Username { get; set; } = string.Empty;

        [Required]
        [MaxLength(128)]
        public string Password { get; set; } = string.Empty;
    }
}