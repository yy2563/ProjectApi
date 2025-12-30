using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using project.Customer.Dto;
using project.Customer.Interface;
using project.Customer.Servise;
using System.Collections.Generic;
using static project.Customer.Dto.UserDto;

namespace project.Customer.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;


        public UsersController(IUserService userService)
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
                return CreatedAtAction(nameof(Register), new { userName = user.UserName }, user);
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
                return CreatedAtAction(nameof(login), new { id = user.UserName }, user);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet("AllUsers")]
        public async Task<ActionResult<IEnumerable<UserDto.getUserDto>>> GetAllUsers()
        {
            IEnumerable < UserDto.getUserDto > userDtos = await _userService.GetAllUsers();
            return Ok(userDtos);
        }

    }

}
