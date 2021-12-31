// <copyright file="UserRepository.cs" company="JoyBoy">
// Copyright (c) JoyBoy. All rights reserved.
// </copyright>

namespace FundooRepository.Repository
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Security.Cryptography;
    using System.Net.Mail;
    using Experimental.System.Messaging;
    using FundooModels;
    using FundooRepository.Context;
    using Microsoft.Extensions.Configuration;
    using StackExchange.Redis;

    /// <summary>
    /// Interact with database
    /// </summary>
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// private declaration of UserContext
        /// </summary>
        private readonly UserContext userContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class
        /// </summary>
        /// <param name="configuration">Configuration</param>
        /// <param name="userContext">UserContext</param>
        public UserRepository(IConfiguration configuration, UserContext userContext)
        {
            this.Configuration = configuration;
            this.userContext = userContext;
        }

        /// <summary>
        /// Gets configuration from project
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// check if email already present or not and pass the data
        /// </summary>
        /// <param name="userData">RegisterModel</param>
        /// <returns>String</returns>
        public string Register(RegisterModel userData)
        {
            try
            {
                var validEmail = this.userContext.User.Where(x => x.Email == userData.Email).FirstOrDefault();
                if (validEmail == null)
                {
                    if (userData != null)
                    {
                        ////Encrypt password with MD5
                        userData.Password = EncryptPassword(userData.Password);
                        ////add data to the database using user context
                        this.userContext.Add(userData);
                        ////Saving data in database
                        this.userContext.SaveChanges();
                        return "Registration Successful";
                    }
                    return "Registration UnSuccessful";
                }
                return "Email Id Already Exists";
            }
            catch (ArgumentNullException e)
            {
                throw new ArgumentNullException(e.Message);
            }
        }
        
        /// <summary>
        /// Checking of email and password with our Dbset User
        /// </summary>
        /// <param name="userData">LoginModel</param>
        /// <returns>String value</returns>
        public string Login(LoginModel userData)
        {
            try
            {
                var validEmail = this.userContext.User.Where(x => x.Email == userData.Email).FirstOrDefault();
                if (validEmail != null)
                {
                    var validPass = this.userContext.User.Where(x => x.Password == EncryptPassword(userData.Password)).FirstOrDefault();
                    if (validPass != null)
                    {
                        
                        ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect("127.0.0.1:6379");
                        IDatabase database = connectionMultiplexer.GetDatabase();
                        database.StringSet(key: "First Name", validEmail.FirstName);
                        database.StringSet(key: "Last Name", validEmail.LastName);
                        database.StringSet(key: "User Id", validEmail.UserID);
                        return "Login Successful";
                    }
                    return "Password is invalid";
                }
                return "Email is invalid";
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Take email and new password
        /// </summary>
        /// <param name="userData">ResetPasswordModel</param>
        /// <returns>String</returns>
        public string ResetPasswrod(ResetPasswordModel userData)
        {
            try
            {
                var validEmail = this.userContext.User.Where(x => x.Email == userData.Email).FirstOrDefault();
                if (validEmail != null)
                {
                    if (userData != null)
                    {
                        validEmail.Password = EncryptPassword(validEmail.Password);
                        //add data to the database using user context
                        this.userContext.Update(validEmail);
                        //Saving data in database
                        this.userContext.SaveChanges();
                        return "Password Reset Successful";
                    }
                }
                return "Enterd Wrong Email";
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Send email to change password
        /// </summary>
        /// <param name="email">Email</param>
        /// <returns>string result</returns>
        public async Task<string> ForgotPassword(string email)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress(this.Configuration["Credentials:EmailId"]);
                mail.To.Add(email);
                mail.Subject = "Test Mail";
                SendMSMQ();
                mail.Body = ReceiveMSMQ();
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(this.Configuration["Credentials:EmailId"], this.Configuration["Credentials:EmailPassword"]);
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                return "Email send Successfully";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Create a Queue to send email
        /// </summary>
        public void SendMSMQ()
        {
            MessageQueue messageQueue;
            if (MessageQueue.Exists(@".\Private$\Fundoo"))
            {
                messageQueue = new MessageQueue(@".\Private$\Fundoo");
            }
            else
            {
                messageQueue = MessageQueue.Create(@".\Private$\Fundoo");
            }
            string body = "This is for Testing SMTP mail from GMAIL";
            messageQueue.Label = "Mail Body";
            messageQueue.Send(body);
        }

        /// <summary>
        /// Recive email
        /// </summary>
        /// <returns>String</returns>
        public string ReceiveMSMQ()
        {
            MessageQueue messageQueue = new MessageQueue(@".\Private$\Fundoo");
            var receivemsg = messageQueue.Receive();
            return receivemsg.ToString();
        }

        /// <summary>
        /// Encrypt password using md5 algorithm
        /// </summary>
        /// <param name="password">password string</param>
        /// <returns>encrypted password in string</returns>
        public string EncryptPassword(string password)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] encrypt;
            UTF8Encoding encode = new UTF8Encoding();
            ////encrypt the given password string into Encrypted data  
            encrypt = md5.ComputeHash(encode.GetBytes(password));
            StringBuilder encryptdata = new StringBuilder();
            ////Create a new string by using the encrypted data  
            for (int i = 0; i < encrypt.Length; i++)
            {
                encryptdata.Append(encrypt[i].ToString());
            }
            return encryptdata.ToString();
        }
    }
}
