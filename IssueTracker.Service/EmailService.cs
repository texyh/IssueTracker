using IssueTracker.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using IssueTracker.Core.Models;
using MimeKit;
using MailKit.Net.Smtp;
using System.Threading.Tasks;
using IssueTracker.Core.Helpers;

namespace IssueTracker.Service
{
    public class EmailService : IEmailService
    {
        public async Task SendAsync(Email email)
        {
            //string FromAddress = "noreply@gmail.com";
            //string FromAdressTitle = "Email from ASP.NET Core 1.1";
            ////To Address  
            //string ToAddress = "onwuzulikee1@gmail.com";
            //string ToAdressTitle = "Microsoft ASP.NET Core";
            //string Subject = "Hello World - Sending email using ASP.NET Core 1.1";
            //string BodyContent = "ASP.NET Core was previously called ASP.NET 5. It was renamed in January 2016. It supports cross-platform frameworks ( Windows, Linux, Mac ) for building modern cloud-based internet-connected applications like IOT, web apps, and mobile back-end.";

            //Smtp Server  
            string SmtpServer = "127.0.0.1"; // this uses paper cut 
            //Smtp Port Number  
            int SmtpPortNumber = 25;

            //var mimeMessage = new MimeMessage();
            //mimeMessage.From.Add(new MailboxAddress(FromAdressTitle, FromAddress));
            //mimeMessage.To.Add(new MailboxAddress(ToAdressTitle, ToAddress));
            //mimeMessage.Subject = Subject;
            //mimeMessage.Body = new TextPart("plain")
            //{
            //    Text = BodyContent

            //};

;            var msg = GetMail(email);

            using (var client = new SmtpClient())
            {

                client.Connect(SmtpServer, SmtpPortNumber, false);
                // Note: only needed if the SMTP server requires authentication  
                // Error 5.5.1 Authentication   
                // client.Authenticate("From Address Email", "Password");
                await client.SendAsync(msg);

                client.Disconnect(true);

            }

            //using (var client = new SmtpClient())
            //{
            //    // XXX - Should this be a little different?
            //    client.ServerCertificateValidationCallback = (s, c, h, e) => true;

            //    client.Connect("smtp.mailgun.org", 587, false);
            //    client.AuthenticationMechanisms.Remove("XOAUTH2");
            //    client.Authenticate("postmaster@sandboxfaddbc2b66f141199ec1ac623ef61824.mailgun.org", "038146f4619bf627ca81d65b6157a1fd");

            //    client.Send(mimeMessage);
            //    client.Disconnect(true);
            //}
            
        }

        private MimeMessage GetMail(Email email)
        {
            var msg = new MimeMessage();
            msg.From.Add(new MailboxAddress("", email.Sender));

            foreach(var recipeint in email.Recipients)
            {
                msg.To.Add(new MailboxAddress("", recipeint));
            }
            
            msg.Subject = email.Subject;
            msg.Body = new TextPart("html")
            {
                Text = email.Body

            };

            return msg;
        }
    }
}
