using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
        [HttpGet("GetAllMentors"), Authorize(Roles = "Admin,Mentor")]
        public async Task<ActionResult<List<MentorResponseDTO>>> GetMentor(int pageNumber = 1, int pageSize = 15)
        {
            var result = await _mentorService.GetAllMentors(pageNumber, pageSize);
            if (!result.Successful)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }


        // GET: api/Mentors/5
        [HttpGet("GetMentor"), Authorize(Roles = "Admin,Mentor")]
        public async Task<ActionResult<MentorResponseDTO>> GetMentor([FromQuery] GetMentorVm vm)
        {
            var result = await _mentorService.GetMentors(vm);
            if (!result.Successful)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }


        // PUT: api/Mentors/5
        [HttpPut("UpdateMentor"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<MentorResponseDTO>> PutMentor(UpdateMentorVm mentor)
        {
            var result = await _mentorService.UpdateMentor(mentor);
            if (!result.Successful)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }


        // DELETE: api/Mentors/5
        [HttpDelete("RemoveMentor/{id}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteMentor(Guid id)
        {
            var result = await _mentorService.RemoveMentor(id);
            if (!result.Successful)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
