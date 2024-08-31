using  API.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentTypeController : ControllerBase
    {
        private readonly IAppointmentTypeService _appointmentTypeService;

        public AppointmentTypeController(IAppointmentTypeService appointmentTypeService)
        {
            this._appointmentTypeService = appointmentTypeService;
        }

        [HttpPost("AddMAppointmentType")]
        public async Task<IActionResult> AddAppointmentType(AppointmentType appointmentType)
        {
            return Ok(_appointmentTypeService.AddAppointmentType(appointmentType));
        }

        [HttpGet("GetAppointmentType")]
         public async Task<ActionResult> GetAppointmentType(int appointmentTypeId)
         {
             return Ok(_appointmentTypeService.GetAppointmentType(appointmentTypeId));
         }

         [HttpGet("GetAllAppointmentTypes")]
         public async Task<ActionResult<List<Municipality>>> GetAllAppointmentTypes()
         {
             return Ok(_appointmentTypeService.GetAllAppointmentTypes());
         }

         [HttpPut("UpdateAppointmentType")]
        public async Task<IActionResult> UpdateAppointmentType(int appointmentTypeId, AppointmentType updatedAppointmentType)
        {
            return Ok(_appointmentTypeService.UpdateAppointmentType(appointmentTypeId, updatedAppointmentType));
        }
        
        [HttpDelete("DeleteAppointmentType")]
        public async Task<IActionResult> DeleteAppointmentType(int appointmentTypeId)
        {
            return Ok(_appointmentTypeService.DeleteAppointmentType(appointmentTypeId));
        }
    }
}