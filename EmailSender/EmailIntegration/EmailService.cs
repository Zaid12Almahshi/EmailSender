using EmailSender.Entity;
using MimeKit;
using MailKit.Net.Smtp;

namespace EmailSender.EmailIntegration;
public class EmailService
{
    public async Task SendEmailAsync(Receiver receiver)
    {
        var emailMessage = new MimeMessage();

        emailMessage.From.Add(new MailboxAddress("zaidalmahshi@gmail.com", "zaidalmahshi@gmail.com"));
        emailMessage.To.Add(new MailboxAddress("", receiver.Email));
        emailMessage.Subject = receiver.Subject;

        var builder = new BodyBuilder { HtmlBody = receiver.Contant };

        if (receiver.File != null)
        {
            using (var stream = receiver.File.OpenReadStream())
            {
                builder.Attachments.Add(receiver.File.FileName, stream);
            }
        }

        emailMessage.Body = builder.ToMessageBody();

        using (var client = new SmtpClient())
        {
            await client.ConnectAsync("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
            await client.AuthenticateAsync("zaidalmahshi@gmail.com", "utldxozrlaxzsbnb");
            await client.SendAsync(emailMessage);
            await client.DisconnectAsync(true);
        }
    }
}

