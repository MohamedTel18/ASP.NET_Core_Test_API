using System.ComponentModel.DataAnnotations;

namespace MagicVilla_VillaAPI.models.DTO
{
    public class UserDTO
    {
        
        public string Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        
        public string? PhoneNumber { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
