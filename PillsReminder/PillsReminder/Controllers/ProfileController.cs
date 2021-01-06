using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PillsReminder.Entities;
using PillsReminder.Helpers;
using PillsReminder.Models;
using PillsReminder.Service;

namespace PillsReminder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    [CustomAuthorize]
    public class ProfileController : ControllerBase
    {
        private readonly ProfileService profileService;

        public ProfileController(ProfileService profileService)
        {
            this.profileService = profileService;
        }

        [HttpGet("InfoProfile")]
        public IActionResult GetUser()
        {
            var user = (User)HttpContext.Items["User"];
            return Ok(profileService.GetUserById(user.Id));
        }

        [HttpPut("UpdateProfile")]
        public IActionResult UpdateUser(UserProfileResponse request)
        {
            var user = (User)HttpContext.Items["User"];
            return Ok(profileService.EditProfile(request, user.Id));
        }

        [HttpDelete("DeleteProfile")]
        public IActionResult DeleteUser()
        {
            var user = (User)HttpContext.Items["User"];
            return Ok(profileService.DeleteUserById(user.Id));
        }

    }
}
