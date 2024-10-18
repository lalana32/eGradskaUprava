using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SmsController : ControllerBase
    {
        private readonly TwilioService _twilioService;

        public SmsController(TwilioService twilioService)
        {
            _twilioService = twilioService;
        }

        [HttpPost("send")]
        public IActionResult SendSms([FromBody] SmsRequest request)
        {
            _twilioService.SendSms(request.To, request.Message);
            return Ok("Message sent successfully.");
        }
    }
}