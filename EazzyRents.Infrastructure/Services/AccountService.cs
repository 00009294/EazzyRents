﻿using EazzyRents.Application.Common.Interfaces.Services;
using System.Net;
using System.Net.Mail;

namespace EazzyRents.Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        private readonly string _smtpServer;
        private readonly int _smtpPort;
        private readonly string _smtpUsername;
        private readonly string _smtpPassword;
        public AccountService(string smtpServer, int smtpPort, string smtpUsername, string smtpPassword)
        {
            _smtpServer = smtpServer;
            _smtpPort = smtpPort;
            _smtpUsername = smtpUsername;
            _smtpPassword = smtpPassword;
        }


        public async Task SendConfirmationEmail(string email, string subject, string message)
        {
            using (var smtpClient = new SmtpClient(_smtpServer, _smtpPort))
            {
                smtpClient.Credentials = new NetworkCredential(_smtpUsername, _smtpPassword);
                smtpClient.EnableSsl = true; // Depending on the SMTP server you might need to enable SSL

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_smtpUsername), // Sender's email address
                    Subject = subject,
                    Body = message,
                    IsBodyHtml = true // Set to true if the message contains HTML
                };
                mailMessage.To.Add(email);

                await smtpClient.SendMailAsync(mailMessage);
            }
        }
    }
}
