﻿using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HistoryOfComputers.Services
{
    // This class is used by the application to send Email and SMS
    // when you turn on two-factor authentication in ASP.NET Identity.
    // For more details see this link https://go.microsoft.com/fwlink/?LinkID=532713
    public class AuthMessageSender : IEmailSender, ISmsSender
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            // Plug in your email service here to send an email.
            // dcowan
            // NOTE: using MailKit
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("History of Computers", "davecowan2016@gmail.com"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            //default plain text message
            //emailMessage.Body = new TextPart("plain") { Text = message };

            //HTML message body
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = message;
            emailMessage.Body = bodyBuilder.ToMessageBody();

            //SETUP SMTP CLIENT (for gmail)
            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 465, SecureSocketOptions.SslOnConnect).ConfigureAwait(false);
                //Note: Since we don't have an OAuth2 token, need is disable XOAUTH2
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                await client.AuthenticateAsync("davecowan2016@gmail.com", "Pre_fect2016").ConfigureAwait(false);
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true).ConfigureAwait(false);
            }

            
        }

        public Task SendSmsAsync(string number, string message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }
}
