using Application.DTOs;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PruebaTecnicaBack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(IUserService userService) : ControllerBase
    {
        
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<UserCreateUpdateDto>> CreateUser([FromBody] UserCreateUpdateDto userDto)
        {
            try
            {
                await userService.AddUserAsync(userDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
