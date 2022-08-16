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
    [Route("api/")]
    [ApiController]
    public class InternsController : ControllerBase
    {
        private readonly MilsatInternAPIContext _context;

        public InternsController(MilsatInternAPIContext context)
        {
            _context = context;
        }

        // GET: api/Interns
        [HttpGet("GetInterns/pageNumber/pageSize")]
        public async Task<ActionResult<IEnumerable<Intern>>> GetIntern(int pageNumber = 1, int pageSize = 1)
        {
            if (_context.Intern == null)
            {
                return NotFound();
            }

            var pagedData = await _context.Intern
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return pagedData;
        }


        [HttpGet("GetIntern/")]
        public async Task<ActionResult<IEnumerable<Intern>>> GetIntern([FromQuery] GetInternVm model)
        {
            if (_context.Intern == null)
            {
                return NotFound();
            }

            if (model.id == null && model.name == null && model.department == null)
            {
                return BadRequest("At least a search query is always required");
            }

            // When ID is received
            if (model.id != null)
            {
                var intern = await _context.Intern.Where(x => x.Id == model.id).FirstOrDefaultAsync();
                if (intern == null)
                {
                    return NotFound("Invalid ID supplied");
                }

                List<Intern> collectedIntern = new List<Intern> { intern };
                return collectedIntern;
            }

            // Received only name without department
            else if (model.name != null && model.department == null)
            {
                var interns = await _context.Intern.Where(x => x.Name.Contains(model.name)).ToListAsync();
                return interns;
            }

            //Received only Department without name
            //else if (model.name == null && model.department != null)
            {
                var interns = await _context.Intern.Where(x => x.Department.Contains(model.department)).ToListAsync();
                return interns;
            }

        }


        // PUT: api/Interns/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("UpdateIntern")]
        public async Task<IActionResult> PutIntern(UpdateInternVm intern)
        {
            var singleIntern = _context.Intern.Where(x => x.Id == intern.Id).FirstOrDefault();

            if (singleIntern == null)
            {
                return NotFound("Invalid ID Supplied");
            }
            singleIntern.Department = intern.Department;

            _context.Entry(singleIntern).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;
            }

            return Ok("Update Successful");
        }

        // POST: api/Interns
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("CreateInterns")]
        public async Task<ActionResult<Intern>> PostIntern(IEnumerable<CreateInternVm> intern)
        {
            if (_context.Intern == null)
            {
                return Problem("Entity set 'MilsatInternsContext.Intern'  is null.");
            }

            foreach (CreateInternVm eachIntern in intern)
            {
                Intern singleIntern = new Intern { Name = eachIntern.Name, Department = eachIntern.Department };
                _context.Intern.Add(singleIntern);
            }

            await _context.SaveChangesAsync();

            return Ok("Interns Asdded Successfully");
        }

        // DELETE: api/Interns/5
        [HttpDelete("RemoveIntern/{id}")]
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
            return (_context.Intern?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
