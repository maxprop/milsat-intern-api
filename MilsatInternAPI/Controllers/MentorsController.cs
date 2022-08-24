using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MilsatInternAPI.Data;
using MilsatInternAPI.Models;
using MilsatInternAPI.ViewModels.Mentors;


namespace MilsatInternAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class MentorsController : ControllerBase
    {
        private readonly MilsatInternAPIContext _context;

        public MentorsController(MilsatInternAPIContext context)
        {
            _context = context;
        }

        // GET: api/Mentors
        [HttpGet("GetAllMentors")]
        public async Task<ActionResult<IEnumerable<MentorDTO>>> GetMentor(int pageNumber = 1, int pageSize = 15)
        {
            if (_context.Mentor == null)
            {
                return NotFound();
            }
            var pagedData = await _context.Mentor.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Include(_intern => _intern.Interns)
                .ToListAsync();

            List<MentorDTO> result = new List<MentorDTO>();
            foreach (Mentor data in pagedData)
            {
                var interns = new List<MentorInternDTO> { };
                foreach (Intern _intern in data.Interns)
                {
                    MentorInternDTO mentorInternDTO = new MentorInternDTO
                    {
                        InternId = _intern.InternId,
                        Name = _intern.Name
                    };
                    interns.Add(mentorInternDTO);
                }

                var single_mentor = new MentorDTO
                {
                    MentorId = data.MentorId,
                    Name = data.Name,
                    Department = data.Department,
                    Status = data.Status,
                    Interns = interns
                };

                result.Add(single_mentor);
            }
            return result;
        }

        // GET: api/Mentors/5
        [HttpGet("GetMentor/{id}")]
        public async Task<ActionResult<MentorDTO>> GetMentor(int id)
        {
          if (_context.Mentor == null)
          {
              return NotFound();
          }
            var mentor = await _context.Mentor.Include(mentor => mentor.Interns)
                                              .FirstOrDefaultAsync(mentor => mentor.MentorId == id);
            if (mentor == null) { return NotFound(); }

            var interns = new List<MentorInternDTO> { };
            foreach (Intern _intern in mentor.Interns)
            {
                MentorInternDTO mentorInternDTO = new MentorInternDTO {
                    InternId = _intern.InternId,
                    Name = _intern.Name };
                interns.Add(mentorInternDTO);
            }

            var single_mentor = new MentorDTO {
                MentorId = mentor.MentorId, Name = mentor.Name, 
                Department = mentor.Department,
                Status = mentor.Status,
                Interns = interns
            };
            return single_mentor;
        }

        // PUT: api/Mentors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("UpdateMentor/{id}")]
        public async Task<IActionResult> PutMentor(int id, Mentor mentor)
        {
            if (id != mentor.MentorId)
            {
                return BadRequest();
            }

            _context.Entry(mentor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MentorExists(id))
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

        // POST: api/Mentors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("AddMentor")]
        public async Task<ActionResult<CreateMentorVm>> PostMentor(CreateMentorVm mentor)
        {
            if (_context.Mentor == null)
            {
                return Problem("Entity set 'MilsatInternAPIContext.Mentor'  is null.");
            }

            Mentor _singleMentor = new Mentor {
                                            MentorId = mentor.MentorId,
                                            Name = mentor.Name ,
                                            Department = mentor.Department,
            };

            _context.Mentor.Add(_singleMentor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMentor", new { id = mentor.MentorId }, mentor);
        }

        // DELETE: api/Mentors/5
        [HttpDelete("RemoveMentor/{id}")]
        public async Task<IActionResult> DeleteMentor(int id)
        {
            if (_context.Mentor == null)
            {
                return NotFound();
            }
            var mentor = await _context.Mentor.FindAsync(id);
            if (mentor == null)
            {
                return NotFound();
            }

            _context.Mentor.Remove(mentor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MentorExists(int id)
        {
            return (_context.Mentor?.Any(e => e.MentorId == id)).GetValueOrDefault();
        }
    }
}
