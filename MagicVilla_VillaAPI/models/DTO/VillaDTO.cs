using System.ComponentModel.DataAnnotations;

namespace MagicVilla_VillaAPI.models.DTO
{
    public class VillaDTO
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public int Occuppency { get; set; }
    }
}
