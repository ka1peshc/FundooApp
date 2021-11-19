using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace FundooRepository
{
    public class EmailForResetPassword
    {
        //public SendEmailForReset(IConfiguration configuration)
        //{
        //    this.Configuration = configuration;
        //}

        //public IConfiguration Configuration { get; }

        public void SendEmail(string email)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("111997luffy@gmail.com");
                //mail.From = new MailAddress(this.Configuration["EmailId"]);
                mail.To.Add(email);
                mail.Subject = "Password Reset Link";
                mail.Body = "This is auto-genrated email";

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("111997luffy@gmail.com", "luffy@111997");
                //SmtpServer.Credentials = new System.Net.NetworkCredential(this.Configuration["EmailId"], this.Configuration["EmailPassword"]);
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
