using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MilsatInternAPI.Data;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using MilsatInternAPI.ViewModels.Interns;
using MilsatInternAPI.Models;
using MilsatInternAPI.Enums;

namespace MilsatInternAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class InternsController : ControllerBase
    {
        private readonly MilsatInternAPIContext _context;
        private readonly ILogger<InternsController> _logger;

        public InternsController(MilsatInternAPIContext context, ILogger<InternsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/Interns
        [HttpGet("GetInterns/pageNumber/pageSize")]
        public async Task<ActionResult<IEnumerable<InternDTO>>> GetIntern(int pageNumber = 1, int pageSize = 15)
        {
            _logger.LogInformation($"Received a request to fetch paginated Intern(s): Request: pageNumber:{pageNumber}, pageSize:{pageSize}");
            if (_context.Intern == null)
            {
                return NotFound();
            }
            try
            {
                var pagedData = await _context.Intern.Include(_intern => _intern.Mentor)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                var dto = new List<InternDTO>();
                foreach (var _intern in pagedData)
                {
                    InternDTO intern_dto = new InternDTO
                    {
                        InternId = _intern.InternId,
                        Name = _intern.Name,
                        Department = _intern.Department,
                        MentorId = _intern.Mentor.MentorId,
                        MentorName = _intern.Mentor.Name
                    };
                    dto.Add(intern_dto);
                 }
                    return dto;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception occured while Fecthing Data Request. Messg: {ex.Message} : StackTrace: {ex.StackTrace}");
                return NotFound();
            }

        }


        [HttpGet("GetIntern/")]
        public async Task<ActionResult<IEnumerable<InternDTO>>> GetIntern([FromQuery] GetInternVm model)
        {
            _logger.LogInformation($"Received a request to Fetch Intern(s): Request:{JsonConvert.SerializeObject(model)}");
            if (_context.Intern == null)
            {
                return NotFound();
            }
            if (model.id == null && model.name == null && model.department == null)
            {
                _logger.LogInformation("No input query received to fetch data");
                return BadRequest("At least a search query is always required");
            }

            // When ID is received
            try
            {

                if (model.id != null)
                {
                    var intern = await _context.Intern.Include(_intern => _intern.Mentor)
                                                      .Where(x => x.InternId == model.id)
                                                      .FirstOrDefaultAsync();
                    if (intern == null)
                    {   
                        _logger.LogInformation("Invalid ID Received.");
                        return NotFound("Invalid ID supplied");
                    }
                    var dto = new InternDTO {   InternId = intern.InternId,
                                                Name = intern.Name, Department = intern.Department,
                                                MentorId = intern.Mentor.MentorId, MentorName = intern.Mentor.Name};
                    List<InternDTO> collectedIntern = new List<InternDTO> { dto };
                    return collectedIntern;
                }

                // Received only name without department
                else if (model.name != null && model.department == null)
                {
                    var interns = await _context.Intern.Include(_intern => _intern.Mentor)
                                                       .Where(x => x.Name.Contains(model.name))
                                                       .ToListAsync();

                    var dto = new List<InternDTO>();
                    foreach (var _intern in interns)
                    {
                        InternDTO intern_dto = new InternDTO
                        {
                            InternId = _intern.InternId,
                            Name = _intern.Name,
                            Department = _intern.Department,
                            MentorId = _intern.Mentor.MentorId,
                            MentorName = _intern.Mentor.Name
                        };
                        dto.Add(intern_dto);
                    }
                    return dto;
                }

                //Received only Department without name
                //else if (model.name == null && model.department != null)
                else
                {
                    var interns = await _context.Intern.Include(_intern => _intern.Mentor)
                                                       .Where(x => x.Department == model.department)
                                                       .ToListAsync();
                    var dto = new List<InternDTO>();
                    foreach (var _intern in interns)
                    {
                        InternDTO intern_dto = new InternDTO
                        {
                            InternId = _intern.InternId,
                            Name = _intern.Name,
                            Department = _intern.Department,
                            MentorId = _intern.Mentor.MentorId,
                            MentorName = _intern.Mentor.Name
                        };
                        dto.Add(intern_dto);
                    }
                    return dto;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception occured while Fecthing Data Request. Messg: {ex.Message} : StackTrace: {ex.StackTrace}");
                return NotFound("Something went wrong");

            }
        }


        // PUT: api/Interns/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("UpdateIntern")]
        public async Task<IActionResult> PutIntern(UpdateInternVm intern)
        {
            _logger.LogInformation($"Received a request to update Intern: Request:{JsonConvert.SerializeObject(intern)}");
            try
            {
                var singleIntern = _context.Intern.Where(x => x.InternId == intern.Id).FirstOrDefault();

                if (singleIntern == null)
                {
                    _logger.LogInformation($"Invalid ID supplied");
                    return NotFound("Invalid ID Supplied");
                }
                if (singleIntern.Department != intern.Department)
                {
                    singleIntern.Department = intern.Department;
                    var availableMentors = await _context.Mentor.Where(mentor => mentor.Department == intern.Department).ToListAsync();
                    int totalAvailableMentors = availableMentors.Count();
                    if (totalAvailableMentors == 0)
                    {
                        return NotFound("No mentor found for this department");
                    }

                    var selector = PickMentor(totalAvailableMentors);
                    var mentor = availableMentors[selector];
                    singleIntern.Mentor = mentor;
                }

                _context.Entry(singleIntern).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                return Ok("Update Successful");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured while Updating Intern. Messg: {ex.Message} : StackTrace: {ex.StackTrace}");
                return NotFound("Something went wrong");

            }
        }

        // POST: api/Interns
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("CreateInterns")]
        public async Task<ActionResult<Intern>> PostIntern(IEnumerable<CreateInternVm> intern)
        {
            _logger.LogInformation($"Received a request to create new Intern(s): Request:{JsonConvert.SerializeObject(intern)}");
            if (_context.Intern == null)
            {
                return Problem("Entity set 'MilsatInternsContext.Intern'  is null.");
            }

            try
            {
                foreach (CreateInternVm eachIntern in intern)
                {
                    var singleIntern = new Intern { Name = eachIntern.Name, Department = eachIntern.Department };

                    var availableMentors = await _context.Mentor.Where(mentor => mentor.Department == eachIntern.Department).ToListAsync();
                    int totalAvailableMentors = availableMentors.Count();
                    if (totalAvailableMentors == 0)
                    {
                        return NotFound("No mentor found for this department");
                    }

                    var selector = PickMentor(totalAvailableMentors);
                    var mentor = availableMentors[selector];
                    singleIntern.Mentor = mentor;

                    _context.Intern.Add(singleIntern);
                }

                await _context.SaveChangesAsync();

                return Ok("Interns Asdded Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured while Creating Intern. Messg: {ex.Message} : StackTrace: {ex.StackTrace}");
                return BadRequest("Something went wrong");
            }
        }

        // DELETE: api/Interns/5
        [HttpDelete("RemoveIntern/{id}")]
        public async Task<IActionResult> DeleteIntern(int id)
        {
            _logger.LogInformation($"Received a request to delete an Intern: Request(intern id):{id}");
            if (_context.Intern == null)
            {
                return NotFound();
            }
            try
            {
                var intern = await _context.Intern.FindAsync(id);
                if (intern == null)
                {
                    return NotFound();
                }

                _context.Intern.Remove(intern);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error occured while Deleting Intern. Messg: {ex.Message} : StackTrace: {ex.StackTrace}");
                return BadRequest("Something went wrong");
            }
        }

        private bool InternExists(int id)
        {
            return (_context.Intern?.Any(e => e.InternId == id)).GetValueOrDefault();
        }

        private int PickMentor(int total)
        {
            Random random = new Random();
            var selector = random.Next(total);
            return selector;
        }
    }
}
