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
            base.OnModelCreating(builder);  
        }  
    }
}