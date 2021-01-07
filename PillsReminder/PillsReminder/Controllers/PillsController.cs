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
    public class PillsController : ControllerBase
    {
        private readonly PillsService pillsService;

        public PillsController(PillsService pillsService)
        {
            this.pillsService = pillsService;
        }

        [HttpPost("CreateDoza")]
        public IActionResult CreateDoza(DozaMedicamentRequest dozaMedicament)
        {
            var user = (User)HttpContext.Items["User"];
            return Ok(pillsService.CreateDoza(dozaMedicament, user.Id));
        }

        [HttpGet("GetLista")]
        public IActionResult GetDoze()
        {
            var user = (User)HttpContext.Items["User"];
            return Ok(pillsService.GetDoze().Where(x => x.User.Id == user.Id));
        }

        [HttpPut("UpdateDoza")]
        public IActionResult UpdateDoza(int IdDoza, bool Luata)
        {
            return Ok(pillsService.UpdateDoza(IdDoza, Luata));
        }

        [HttpDelete("DeleteDoza")]
        public IActionResult DeleteDoza(int IdDoza)
        {
            return Ok(pillsService.DeleteDoza(IdDoza));
        }


    }
}
