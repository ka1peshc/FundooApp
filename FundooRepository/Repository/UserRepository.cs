using FundooModels;
using FundooRepository.Context;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq ;

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

        EncryptingClass encrypt = new EncryptingClass();
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
                        userData.Password = encrypt.EncryptPassword(userData.Password);
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
                    if (userData != null)
                    {
                        var validPassword = this.userContext.User.Where(x => x.Password == userData.Password).FirstOrDefault();
                        return "Login Successful";
                    }
                }
                return "Email or Password Invalid";
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

                        validEmail.Password = encrypt.EncryptPassword(validEmail.Password);
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
    }
}
