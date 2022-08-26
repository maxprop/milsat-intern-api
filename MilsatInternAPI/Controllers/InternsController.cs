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
using MilsatInternAPI.Interfaces;
using MilsatInternAPI.ViewModels;

namespace MilsatInternAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class InternsController : ControllerBase
    {
        private readonly IInternService _internService;
        public InternsController(IInternService service)
        {
            _internService = service;
        }


        // GET: api/Interns
        [HttpGet("GetAllInterns")]
        public async Task<ActionResult<List<InternDTO>>> GetIntern(int pageNumber = 1, int pageSize = 15)
        {
            var result = await _internService.GetAllInterns(pageNumber, pageSize);
            if (!result.IsSuccessful)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }


        [HttpGet("GetIntern/")]
        public async Task<ActionResult<List<InternDTO>>> GetIntern([FromQuery] GetInternVm model)
        {
            var result = await _internService.GetInterns(model);
            if (!result.IsSuccessful)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }


        // PUT: api/Interns/5
        [HttpPut("UpdateIntern")]
        public async Task<ActionResult<InternDTO>> PutIntern(UpdateInternVm intern)
        {
            var result = await _internService.UpdateIntern(intern);
            if (!result.IsSuccessful)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }


        // POST: api/Interns
        [HttpPost("AddIntern")]
        public async Task<ActionResult<InternDTO>> PostIntern(List<CreateInternVm> intern)
        {

            var result = await _internService.AddIntern(intern);
            if (!result.IsSuccessful)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }


        // DELETE: api/Interns/5
        [HttpDelete("RemoveIntern")]
        public async Task<IActionResult> DeleteIntern(int id)
        {
            var result = await _internService.RemoveIntern(id);
            if (!result.IsSuccessful)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}