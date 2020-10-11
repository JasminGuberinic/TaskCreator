using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IJwtAuthenticationManager jwtAuthenticationManager;

        public LoginController(IJwtAuthenticationManager jwtAuthenticationManager)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]UserCredentials userCredentials)
        {
            var token = jwtAuthenticationManager.Authenticate(userCredentials.UserName, userCredentials.Password);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }

        [HttpGet]
        public string Get()
        {
            return "Welcome to task App!";
        }
    }
}
