using EmailProject.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmailProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;
        public EmailController(IServiceProvider serviceProvider)
        {
          _emailService = serviceProvider.GetRequiredService<IEmailService>();
        }

        [HttpPost]
        [Route("/api/[controller]/send-mail")]
        public IActionResult SendMail([FromBody]SendEmailModel request) {
            try
            {
                _emailService.SendEmail(request);
                return Ok("Send Mail success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
