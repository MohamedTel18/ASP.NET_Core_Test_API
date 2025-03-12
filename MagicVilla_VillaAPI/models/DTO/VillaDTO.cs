using System.ComponentModel.DataAnnotations;

namespace MagicVilla_VillaAPI.models.DTO
{
    public class VillaDTO
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public string Details { get; set; }

        [Required]
        public double Rate { get; set; }
        public int Occuppency { get; set; }
        public int sqft { get; set; }
        public string ImageUrl { get; set; }
        public string Amenty { get; set; }
    }
}
