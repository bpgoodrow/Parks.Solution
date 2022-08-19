using Microsoft.EntityFrameworkCore;

namespace Parks.Models
{
    public class StateParksContext : DbContext
    {
        public StateParksContext(DbContextOptions<StateParksContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
          builder.Entity<StatePark>()
              .HasData(
                  new StatePark { StateParkId = 1, StateParkName = "Crater Lake", StateParkState = "Oregon" }
              );
        }

        public DbSet<StatePark> StateParks { get; set; }
    }
}