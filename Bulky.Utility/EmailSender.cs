﻿using Microsoft.AspNetCore.Identity.UI.Services;

namespace Bulky.Utility
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            //Methode d'envoi d'eamil.
            //throw new NotImplementedException();
            return Task.CompletedTask;
        }
    }
}
