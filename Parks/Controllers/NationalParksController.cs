using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parks.Models;
using Microsoft.AspNetCore.Authorization;

namespace Parks.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class NationalParksController : ControllerBase
  {
    private readonly NationalParksContext _db;

    public NationalParksController(NationalParksContext db)
    {
      _db = db;
    }

    // GET: api/nationalparks
    [HttpGet]
    public async Task<ActionResult<IEnumerable<NationalPark>>> Get(string nationalparkname, string nationalparkstate)
    {
      var query = _db.NationalParks.AsQueryable();

      if (nationalparkname != null)
      {
        query = query.Where(entry => entry.NationalParkName == nationalparkname);
      }

      if (nationalparkstate != null)
      {
        query = query.Where(entry => entry.NationalParkState == nationalparkstate);
      }    

      return await query.ToListAsync();
    }

    // GET: api/nationalparks/1
    [HttpGet("{id}")]
    public async Task<ActionResult<NationalPark>> GetNationalPark(int id)
    {
        var nationalpark = await _db.NationalParks.FindAsync(id);

        if (nationalpark == null)
        {
            return NotFound();
        }

        return nationalpark;
    }

    // PUT: api/nationalparks/1
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, NationalPark nationalpark)
    {
      if (id != nationalpark.NationalParkId)
      {
        return BadRequest();
      }

      _db.Entry(nationalpark).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!NationalParkExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    // POST: api/nationalparks
    [HttpPost]
    public async Task<ActionResult<NationalPark>> Post(NationalPark nationalpark)
    {
      _db.NationalParks.Add(nationalpark);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetNationalPark), new { id = nationalpark.NationalParkId }, nationalpark);
    }

    // DELETE: api/nationalparks/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteNationalPark(int id)
    {
      var nationalpark = await _db.NationalParks.FindAsync(id);
      if (nationalpark == null)
      {
        return NotFound();
      }

      _db.NationalParks.Remove(nationalpark);
      await _db.SaveChangesAsync();

      return NoContent();
    }

    private bool NationalParkExists(int id)
    {
      return _db.NationalParks.Any(e => e.NationalParkId == id);
    }
  }
}