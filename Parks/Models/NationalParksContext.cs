using Microsoft.EntityFrameworkCore;

namespace Parks.Models
{
    public class NationalParksContext : DbContext
    {
        public NationalParksContext(DbContextOptions<NationalParksContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
          builder.Entity<NationalPark>()
              .HasData(
                  new NationalPark { NationalParkId = 1, NationalParkName = "Olympic", NationalParkState = "Washington" }
              );
        }

        public DbSet<NationalPark> NationalParks { get; set; }
    }
}