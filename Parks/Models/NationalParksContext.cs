using Microsoft.EntityFrameworkCore;

namespace Parks.Models
{
    public class NationalParksContext : DbContext
    {
        public NationalParksContext(DbContextOptions<NationalParksContext> options)
            : base(options)
        {
        }

        public DbSet<NationalPark> NationalParks { get; set; }
    }
}