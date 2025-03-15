using System.ComponentModel.DataAnnotations;

namespace MagicVilla_VillaAPI.models.DTO
{
    public class LoginDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
