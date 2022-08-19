using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parks.Models;

namespace Parks.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class StateParksController : ControllerBase
  {
    private readonly StateParksContext _db;

    public StateParksController(StateParksContext db)
    {
      _db = db;
    }

    // GET: api/stateparks
    [HttpGet]
    public async Task<ActionResult<IEnumerable<StatePark>>> Get(string stateparkname, string stateparkstate)
    {
      var query = _db.StateParks.AsQueryable();

      if (stateparkname != null)
      {
        query = query.Where(entry => entry.StateParkName == stateparkname);
      }

      if (stateparkstate != null)
      {
        query = query.Where(entry => entry.StateParkState == stateparkstate);
      }    

      return await query.ToListAsync();
    }

    // GET: api/stateparks/1
    [HttpGet("{id}")]
    public async Task<ActionResult<StatePark>> GetStatePark(int id)
    {
        var statepark = await _db.StateParks.FindAsync(id);

        if (statepark == null)
        {
            return NotFound();
        }

        return statepark;
    }

    // PUT: api/stateparks/1
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, StatePark statepark)
    {
      if (id != statepark.StateParkId)
      {
        return BadRequest();
      }

      _db.Entry(statepark).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!StateParkExists(id))
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

    // POST: api/stateparks
    [HttpPost]
    public async Task<ActionResult<StatePark>> Post(StatePark statepark)
    {
      _db.StateParks.Add(statepark);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetStatePark), new { id = statepark.StateParkId }, statepark);
    }

    // DELETE: api/stateparks/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStatePark(int id)
    {
      var statepark = await _db.StateParks.FindAsync(id);
      if (statepark == null)
      {
        return NotFound();
      }

      _db.StateParks.Remove(statepark);
      await _db.SaveChangesAsync();

      return NoContent();
    }

    private bool StateParkExists(int id)
    {
      return _db.StateParks.Any(e => e.StateParkId == id);
    }
  }
}