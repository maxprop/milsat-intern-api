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
using MilsatInternAPI.Models.Interns;

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
        public async Task<ActionResult<IEnumerable<Intern>>> GetIntern(int pageNumber = 1, int pageSize = 1)
        {
            _logger.LogInformation($"Received a request to fetch paginated Intern(s): Request: pageNumber:{pageNumber}, pageSize:{pageSize}");
            if (_context.Intern == null)
            {
                return NotFound();
            }
            try
            {
                var pagedData = await _context.Intern
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();
                return pagedData;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception occured while Fecthing Data Request. Messg: {ex.Message} : StackTrace: {ex.StackTrace}");
                return NotFound();
            }

        }


        [HttpGet("GetIntern/")]
        public async Task<ActionResult<IEnumerable<Intern>>> GetIntern([FromQuery] GetInternVm model)
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
                    var intern = await _context.Intern.Where(x => x.Id == model.id).FirstOrDefaultAsync();
                    if (intern == null)
                    {
                        _logger.LogInformation("Invalid ID Received.");
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
                else
                {
                    var interns = await _context.Intern.Where(x => x.Department.Contains(model.department)).ToListAsync();
                    return interns;
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
                var singleIntern = _context.Intern.Where(x => x.Id == intern.Id).FirstOrDefault();

                if (singleIntern == null)
                {
                    _logger.LogInformation($"Invalid ID supplied");
                    return NotFound("Invalid ID Supplied");
                }
                singleIntern.Department = intern.Department;

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
                    Intern singleIntern = new Intern { Name = eachIntern.Name, Department = eachIntern.Department };
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
            return (_context.Intern?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
