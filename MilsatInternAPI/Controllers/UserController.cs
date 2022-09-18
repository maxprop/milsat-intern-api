using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MilsatInternAPI.Interfaces;
using MilsatInternAPI.ViewModels.Users;

namespace MilsatInternAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/Interns
        [HttpGet("GetAllUsers"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<UserResponseDTO>>> GetUsers(int pageNumber = 1, int pageSize = 15)
        {
            var result = await _userService.GetAllUsers(pageNumber, pageSize);
            if (!result.Successful)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("DeleteUser/{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<UserResponseDTO>>> DeleteUser(Guid id)
        {
            var result = await _userService.RemoveUser(id);
            if (!result.Successful)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
