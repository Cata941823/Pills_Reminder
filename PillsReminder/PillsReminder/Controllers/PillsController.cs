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

        [HttpGet("GetListaDoze")]
        public IActionResult GetDoze()
        {
            var user = (User)HttpContext.Items["User"];
            return Ok(pillsService.GetDoze());
        }

        [HttpGet("GetListaPastile")]
        public IActionResult GetPastile()
        {
            var user = (User)HttpContext.Items["User"];
            return Ok(pillsService.GetPastile());
        }


        [HttpPut("UpdateDoza")]
        public IActionResult UpdateDoza(DozaMedicamentRequestIdLuata doza)
        {
            return Ok(pillsService.UpdateDoza(doza.Id, doza.Luata));
        }

        [HttpDelete("DeleteDoza")]
        public IActionResult DeleteDoza(DozaMedicamentRequestId IdDoza)
        {
            return Ok(pillsService.DeleteDoza(IdDoza.Id));
        }


    }
}
