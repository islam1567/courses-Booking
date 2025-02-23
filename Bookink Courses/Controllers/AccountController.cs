using Bookink_Courses.Models.DTOs;
using Bookink_Courses.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bookink_Courses.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuth service;

        public AccountController(IAuth service)
        {
            this.service = service;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await service.RegisterAsync(dto);
            if (!result.IsAuthantication)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await service.LoginAsync(dto);
            if(!result.IsAuthantication)
                return BadRequest(result.Message);

            return Ok(result);
        }    
    }
}
