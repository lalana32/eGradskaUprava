using API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController:ControllerBase
    {
         private readonly IEmailService _emailService;

    public EmailController(IEmailService emailService)
    {
        _emailService = emailService;
    }

    [HttpGet("send")]
public async Task<IActionResult> SendEmail()
{
   /* if (string.IsNullOrEmpty(request.ToEmail))
        return BadRequest(new { Title = "Invalid email", Detail = "Email address cannot be null or empty." });

    if (string.IsNullOrEmpty(request.Subject))
        return BadRequest(new { Title = "Invalid subject", Detail = "Subject cannot be null or empty." });

    if (string.IsNullOrEmpty(request.Message))
        return BadRequest(new { Title = "Invalid message", Detail = "Message cannot be null or empty." });
*/
    try
    {
        await _emailService.SendEmailAsync("ikanoviczeljko362@gmail.com", "Test", "test");
        return Ok(new { Message = "Email sent successfully." });
    }
    catch (Exception ex)
    {
        return StatusCode(500, new { Title = "Error sending email", Detail = ex.Message });
    }
}
    }
}