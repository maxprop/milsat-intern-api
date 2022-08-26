using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MilsatInternAPI.Data;
using MilsatInternAPI.Interfaces;
using MilsatInternAPI.Models;
using MilsatInternAPI.ViewModels.Mentors;


namespace MilsatInternAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class MentorsController : ControllerBase
    {
        private readonly IMentorService _mentorService;

        public MentorsController(IMentorService service)
        {
            _mentorService = service;
        }


        // GET: api/Mentors
        [HttpGet("GetAllMentors")]
        public async Task<ActionResult<List<MentorDTO>>> GetMentor(int pageNumber = 1, int pageSize = 15)
        {
            var result = await _mentorService.GetAllMentors(pageNumber, pageSize);
            if (!result.IsSuccessful)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }


        // GET: api/Mentors/5
        [HttpGet("GetMentor/{id}")]
        public async Task<ActionResult<MentorDTO>> GetMentor([FromQuery] GetMentorVm vm)
        {
            var result = await _mentorService.GetMentors(vm);
            if (!result.IsSuccessful)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }


        // PUT: api/Mentors/5
        [HttpPut("UpdateMentor")]
        public async Task<ActionResult<MentorDTO>> PutMentor(UpdateMentorVm mentor)
        {
            var result = await _mentorService.UpdateMentor(mentor);
            if (!result.IsSuccessful)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }


        // POST: api/Mentors
        [HttpPost("AddMentor")]
        public async Task<ActionResult<List<MentorDTO>>> PostMentor(List<CreateMentorVm> mentors)
        {
            var result = await _mentorService.AddMentor(mentors);
            if (!result.IsSuccessful)
            {
                return BadRequest(result);
            }
            return Ok(result);

        }


        // DELETE: api/Mentors/5
        [HttpDelete("RemoveMentor/{id}")]
        public async Task<IActionResult> DeleteMentor(int id)
        {
            var result = await _mentorService.RemoveMentor(id);
            if (!result.IsSuccessful)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
