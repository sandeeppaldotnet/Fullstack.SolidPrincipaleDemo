using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SolidPrincipaleDemo.Interfaces;
using SolidPrincipaleDemo.Models;
using SolidPrincipaleDemo.Services;

namespace SolidPrincipaleDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationsController : ControllerBase
    {
        private readonly OrderEmailService _orderEmailService;
        private readonly ISmsSender _smsSender;
        private readonly IWhatsAppSender _whatsAppSender;

        public NotificationsController(
            OrderEmailService orderEmailService,
            ISmsSender smsSender,
            IWhatsAppSender whatsAppSender)
        {
            _orderEmailService = orderEmailService;
            _smsSender = smsSender;
            _whatsAppSender = whatsAppSender;
        }

        [HttpPost("email")]
        public IActionResult SendEmail(NotificationRequest request)
        {
            _orderEmailService.SendOrderConfirmation(
                request.Recipient,
                request.Message);

            return Ok(new
            {
                Message = "Email notification simulated."
            });
        }

        [HttpPost("sms")]
        public IActionResult SendSms(NotificationRequest request)
        {
            _smsSender.SendSms(
                request.Recipient,
                request.Message);

            return Ok(new
            {
                Message = "SMS notification simulated."
            });
        }

        [HttpPost("whatsapp")]
        public IActionResult SendWhatsApp(NotificationRequest request)
        {
            _whatsAppSender.SendWhatsApp(
                request.Recipient,
                request.Message);

            return Ok(new
            {
                Message = "WhatsApp notification simulated."
            });
        }
    }

}
