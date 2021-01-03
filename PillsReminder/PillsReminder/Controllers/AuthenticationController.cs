using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PillsReminder.Entities;
using PillsReminder.Helpers;
using PillsReminder.Interfaces;
using PillsReminder.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PillsReminder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserService userService;

        public AuthController(UserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("register")]
        public IActionResult Register(AuthenticationRequest request)
        {
            userService.Register(request);
            return Ok();
        }

        [HttpPost("login")]
        public IActionResult Login(AuthenticationRequest request)
        {
            return Ok(userService.Login(request));
        }
    }
}
