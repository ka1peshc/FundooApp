﻿using FundooModels;
using FundooRepository.Context;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq ;
using System.Security.Cryptography;
using Experimental.System.Messaging;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using StackExchange.Redis;

namespace FundooRepository.Repository
{
    public class UserRepository : IUserRepository
    {
        //reading user context and reading configuration
        private readonly UserContext userContext;

        public UserRepository(IConfiguration configuration, UserContext userContext)
        {
            this.Configuration = configuration;
            this.userContext = userContext;
        }

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
                //Fetching if any email exist 
                //this.userContext.User is reference to FundooModels/RegisterModel.cs
                var validEmail = this.userContext.User.Where(x => x.Email == userData.Email).FirstOrDefault();
                if (validEmail == null)
                {
                    if (userData != null)
                    {
                        //Encrypt password with MD5
                        userData.Password = EncryptPassword(userData.Password);
                        //add data to the database using user context
                        this.userContext.Add(userData);
                        //Saving data in database
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
        public string ReceiveMSMQ()
        {
            MessageQueue messageQueue = new MessageQueue(@".\Private$\Fundoo");
            var receivemsg = messageQueue.Receive();
            return receivemsg.ToString();
        }

        public string EncryptPassword(string password)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] encrypt;
            UTF8Encoding encode = new UTF8Encoding();
            //encrypt the given password string into Encrypted data  
            encrypt = md5.ComputeHash(encode.GetBytes(password));
            StringBuilder encryptdata = new StringBuilder();
            //Create a new string by using the encrypted data  
            for (int i = 0; i < encrypt.Length; i++)
            {
                encryptdata.Append(encrypt[i].ToString());
            }
            return encryptdata.ToString();
        }

        public string GenerateToken(string email)
        {
            byte[] key = Encoding.UTF8.GetBytes(this.Configuration["Secret"]);
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);
            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                      new Claim(ClaimTypes.Name, email)}),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(securityKey,
                SecurityAlgorithms.HmacSha256Signature)
            };

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken token = handler.CreateJwtSecurityToken(descriptor);
            return handler.WriteToken(token);
        }

    }
}
