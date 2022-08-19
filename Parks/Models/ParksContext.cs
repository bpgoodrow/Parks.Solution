using Microsoft.EntityFrameworkCore;

namespace Parks.Models
{
  public class ParksContext : Dbcontext
  {
    public ParksContext(DbContextOptions<ParksContext> options)
      : base(options)
      {
      }
  }
}