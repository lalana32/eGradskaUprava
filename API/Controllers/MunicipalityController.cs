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

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(_municipalityService.GetAllMunicipalites());
        }
    }
}