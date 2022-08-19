using Microsoft.EntityFrameworkCore;

namespace Parks.Models
{
    public class StateParksContext : DbContext
    {
        public StateParksContext(DbContextOptions<StateParksContext> options)
            : base(options)
        {
        }

        public DbSet<StatePark> StateParks { get; set; }
    }
}