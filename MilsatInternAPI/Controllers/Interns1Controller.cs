using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MilsatInternAPI.Data;
using MilsatInternAPI.Models;

namespace MilsatInternAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Interns1Controller : ControllerBase
    {
        private readonly MilsatInternAPIContext _context;

        public Interns1Controller(MilsatInternAPIContext context)
        {
            _context = context;
        }

        // GET: api/Interns1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Intern>>> GetIntern()
        {
          if (_context.Intern == null)
          {
              return NotFound();
          }
            return await _context.Intern.ToListAsync();
        }

        // GET: api/Interns1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Intern>> GetIntern(int id)
        {
          if (_context.Intern == null)
          {
              return NotFound();
          }
            var intern = await _context.Intern.FindAsync(id);

            if (intern == null)
            {
                return NotFound();
            }

            return intern;
        }

        // PUT: api/Interns1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIntern(int id, Intern intern)
        {
            if (id != intern.InternId)
            {
                return BadRequest();
            }

            _context.Entry(intern).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InternExists(id))
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

        // POST: api/Interns1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Intern>> PostIntern(Intern intern)
        {
          if (_context.Intern == null)
          {
              return Problem("Entity set 'MilsatInternAPIContext.Intern'  is null.");
          }
            _context.Intern.Add(intern);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIntern", new { id = intern.InternId }, intern);
        }

        // DELETE: api/Interns1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIntern(int id)
        {
            if (_context.Intern == null)
            {
                return NotFound();
            }
            var intern = await _context.Intern.FindAsync(id);
            if (intern == null)
            {
                return NotFound();
            }

            _context.Intern.Remove(intern);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InternExists(int id)
        {
            return (_context.Intern?.Any(e => e.InternId == id)).GetValueOrDefault();
        }
    }
}
