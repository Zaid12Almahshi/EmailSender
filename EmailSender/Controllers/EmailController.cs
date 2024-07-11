using EmailSender.EmailIntegration;
using EmailSender.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmailSender.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class EmailController : ControllerBase
{
    private readonly EmailService _emailService;

    public EmailController(EmailService emailService)
    {
        _emailService = emailService;
    }

    [HttpPost]
    public async Task<IActionResult> SendEmail([FromForm] Receiver receiver)
    {
        if (ModelState.IsValid)
        {
            await _emailService.SendEmailAsync(receiver);
            return Ok(new { message = "Email sent successfully!" });
        }

        return BadRequest(ModelState);
    }
}

