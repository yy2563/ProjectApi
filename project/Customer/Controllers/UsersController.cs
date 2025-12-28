using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using project.Customer.Dto;
using project.Customer.Interface;
using project.Customer.Servise;

namespace project.Customer.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController: ControllerBase
    {
        private readonly IUserService _userService;

    
        public UsersController( IUserService userService)
        {
            _userService = userService;
        }
        //register
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register([FromBody] UserDto.registerDto register) 
        {

            try
            {
                var user = await _userService.CreateUser(register);
                return CreatedAtAction(nameof(Register), new { id = user.Id }, user);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        //login
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login([FromBody] UserDto.loginDto login)
        {
            try
            {
                var user = await _userService.LoginUser(login);
                return CreatedAtAction(nameof(login), new { id = user.UserName}, user);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
            
    

}
