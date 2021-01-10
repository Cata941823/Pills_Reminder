using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PillsReminder.Entities;
using PillsReminder.Service;
using PillsReminder.Repository;
using PillsReminder.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace PillsReminder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class AuthController : ControllerBase
    {
        private readonly UserService userService;

        public AuthController(UserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            return Ok(userService.Register(request));
        }

        [HttpPost("login")]
        public IActionResult Login(AuthenticationRequest request)
        {
            return Ok(userService.Login(request));
        }

        [HttpGet("Inform")]
        public IActionResult Info() => Ok("Infoooo");
    }
}
