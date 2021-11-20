using FundooModels;
using FundooRepository;
using FundooRepository.Repository;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace FundooManager.Manager
{
    public class UserManager : IUserManager
    {
        //Declaring obj for the IUserRepository
        private readonly IUserRepository repository;

        public UserManager(IUserRepository repository)
        {
            this.repository = repository;
        }
        //register pass the user data to the repository
        public string Register(RegisterModel userData)
        {
            try
            {
                return this.repository.Register(userData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Data inserted properly call Repository login method
        /// </summary>
        /// <param name="userData">LoginModel</param>
        /// <returns>passing data to repository</returns>
        public string Login(LoginModel userData)
        {
            try
            {
                return this.repository.Login(userData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Check if new password is successful
        /// </summary>
        /// <param name="userData">ResetPasswordModel</param>
        /// <returns>call to repository</returns>
        public string ResetPassword(ResetPasswordModel userData)
        {
            try
            {
                return this.repository.ResetPasswrod(userData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string ForgotPassword(string email)
        {
            try
            {
                SendEmail(email);
                //return this.repository.ResetPasswrod(userData);
                return "successful";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

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
