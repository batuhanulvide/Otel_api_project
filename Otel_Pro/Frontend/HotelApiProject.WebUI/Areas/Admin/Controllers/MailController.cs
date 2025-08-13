using HotelApiProject.WebUI.Models.Mail;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace HotelApiProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    public class MailController : Controller
    {
        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("Index")]
        public IActionResult Index(MailViewModel model)
        {
            MimeMessage mimeMessage = new MimeMessage();

            //Kimden 
            MailboxAddress mailboxAddressFrom = new MailboxAddress("Hotel Api - Admin", "hotelapi@batuhanyalinsoftware.com.tr");
            mimeMessage.From.Add(mailboxAddressFrom);

            //Kime 
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", model.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);
            //Mesaj içeriği 
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = model.Body;

            mimeMessage.Subject = model.Subject;
            mimeMessage.Body = bodyBuilder.ToMessageBody();
            mimeMessage.Date = model.SendingDate;
            //Smtp Ayarları (MailKitSmtp)
            SmtpClient client = new SmtpClient();
            //Smtp Bağlantı Adresi
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
            smtpClient.Connect("mail.batuhanyalinsoftware.com.tr", 465, SecureSocketOptions.SslOnConnect);
            smtpClient.Authenticate("hotelapi@batuhanyalinsoftware.com.tr", "3rNa@023c");
            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);
            return View();
        }
    }
}
