using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text.RegularExpressions;
using Tesseract;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OcrController : ControllerBase
    {
        private readonly string _tessDataPath = Path.Combine(Directory.GetCurrentDirectory(), "tessdata");

        [HttpPost("upload")]
        public IActionResult UploadImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Fajl nije pronađen.");

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "uploads", file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            string extractedText = PerformOcr(filePath);
            string result = ExtractJMBG(extractedText);

            return Ok(new { jmbg = result });
        }

        private string PerformOcr(string imagePath)
        {
            using (var engine = new TesseractEngine(_tessDataPath, "sr", EngineMode.Default))
            {
                using (var img = Pix.LoadFromFile(imagePath))
                {
                    using (var page = engine.Process(img))
                    {
                        return page.GetText();
                    }
                }
            }
        }

        private string ExtractJMBG(string ocrText)
        {
            // Prikazivanje prepoznatog teksta
            Console.WriteLine($"Prepoznati tekst: {ocrText}");

            // Regularni izraz za pretragu JMBG
            var match = Regex.Match(ocrText, @"\b\d{13}\b");

            if (match.Success)
            {
                string jmbg = match.Value;
                return $"Matični broj: {jmbg}";
            }

            return "Matični broj nije prepoznat.";
        }
    }
}
