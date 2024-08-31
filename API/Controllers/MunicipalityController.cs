using  API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;  // Required for EF Core
using System.Collections.Generic;  // Required for List<>
using System.Linq;  // Required for LINQ methods like ToList()
using System.Threading.Tasks;
namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MunicipalityController:ControllerBase
    {
        private readonly IMunicipalityService _municipalityService;

        public MunicipalityController(IMunicipalityService municipalityService)
        {
            _municipalityService= municipalityService;
        }

        [HttpPost("AddMunicipality")]
        public async Task<IActionResult> AddMunicipality(Municipality municipality)
        {
            return Ok(_municipalityService.AddMunicipality(municipality));
        }

        [HttpGet("GetMunicipality")]
         public async Task<ActionResult> GetMunicipality(string zipCode)
         {
             return Ok(_municipalityService.GetMunicipality(zipCode));
         }

         [HttpGet("GetAllMunicipalities")]
         public async Task<ActionResult<List<Municipality>>> GetAllMunicipalities()
         {
             return Ok(_municipalityService.GetAllMunicipalities());
         }

         [HttpPut("UpdateMunicipality")]
        public async Task<IActionResult> UpdateMunicipality(string zipCode, Municipality updatedMunicipality)
        {
            return Ok(_municipalityService.UpdateMunicipality(zipCode, updatedMunicipality));
        }
        
        [HttpDelete("DeleteMunicipality")]
        public async Task<IActionResult> DeleteMunicipality(string zipCode)
        {
            return Ok(_municipalityService.DeleteMunicipality(zipCode));
        }
    }
}