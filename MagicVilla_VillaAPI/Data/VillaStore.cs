using MagicVilla_VillaAPI.models.DTO;

namespace MagicVilla_VillaAPI.Data
{
    public static class VillaStore
    {
        public static List<VillaDTO> villaList = new List<VillaDTO>
        {
                new VillaDTO() { Id = 1, Name = "Villa1" ,Occuppency=4},
                new VillaDTO() { Id = 2, Name = "Villa2",Occuppency=3 }
        };
    }
}