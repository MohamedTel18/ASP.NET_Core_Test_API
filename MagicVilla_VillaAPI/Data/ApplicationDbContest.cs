using MagicVilla_VillaAPI.models;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_VillaAPI.Data
{
    public class ApplicationDbContest:DbContext
    {
        public ApplicationDbContest(DbContextOptions<ApplicationDbContest> options) 
            :base(options)
        {

        }
        public DbSet<Villa> Villas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
            new Villa()
            {
                Id = 1,
                Name = "Villa 1",
                Details = "Villa 1 Details",
                Rate = 100,
                Occuppency = 4,
                sqft = 2000,
                ImageUrl = "",
                Amenty = "Amenty 1",
                CreatedDate = new DateTime(2025, 11, 27)
            },
            new Villa()
            {
                Id = 2,
                Name = "Villa 2",
                Details = "Villa 2 Details",
                Rate = 100,
                Occuppency = 4,
                sqft = 2000,
                ImageUrl = "",
                Amenty = "Amenty 2",
                CreatedDate = new DateTime(2022, 2, 10)
            }); 
        }
    }
}