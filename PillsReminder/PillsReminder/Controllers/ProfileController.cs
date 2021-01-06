using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PillsReminder.Entities;
using PillsReminder.Helpers;
using PillsReminder.Service;

namespace PillsReminder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class ProfileController : ControllerBase
    {
        private readonly ProfileService profileService;
        public ProfileController(ProfileService profileService)
        {
            this.profileService = profileService;
        }

        [HttpGet("Users")]
        public IActionResult GetAll()
        {
            var user = (User)HttpContext.Items["User"];
            return Ok(profileService.GetAll().Where(x => x.Id == user.Id).ToList());
        }

        [CustomAuthorize] 
        [HttpGet("InfoProfile")]
        public string InfoProfile()
        {
            return "Works";
        }

    }
}
