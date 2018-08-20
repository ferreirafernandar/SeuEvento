﻿using System.Threading.Tasks;

namespace SeuEvento.Site.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
