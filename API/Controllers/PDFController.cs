using Microsoft.AspNetCore.Mvc;
using API.Services.Interfaces;
using API.Services;
namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PDFController:ControllerBase
    {
        private readonly IPDFService _pdfService;

        public PDFController(IPDFService pdfService)
        {
            _pdfService=pdfService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAction()
        {
            var pdf =  _pdfService.CreatePdf("zeljko","ikanovic");
            return Ok(pdf);
        }
    }
}