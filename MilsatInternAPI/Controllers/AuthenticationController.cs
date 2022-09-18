using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilsatInternAPI.Interfaces;
using MilsatInternAPI.ViewModels;
using MilsatInternAPI.ViewModels.Interns;
using MilsatInternAPI.ViewModels.Mentors;

namespace MilsatInternAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IInternService _internService;
        private readonly IMentorService _mentorService;
        private readonly IAuthentication _authService;
        public AuthenticationController(IInternService internService, IMentorService mentorService, IAuthentication authService)
        {
            _internService = internService;
            _mentorService = mentorService;
            _authService = authService;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<AuthResponseDTO>> Login(UserLoginDTO request)
        {
            var result = await _authService.Login(request);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("RegisterIntern"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<InternResponseDTO>> RegisterIntern(CreateInternDTO intern) 
        {
            var result = await _internService.AddIntern(intern);
            if (!result.Successful)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("RegisterMentor"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<InternResponseDTO>> RegisterMentor(List<CreateMentorVm> mentor)
        {
            var result = await _mentorService.AddMentor(mentor);
            if (!result.Successful)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("RefreshToken")]
        public async Task<ActionResult<string>> RefreshToken()
        {
            var response = await _authService.RefreshToken();
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }

}
