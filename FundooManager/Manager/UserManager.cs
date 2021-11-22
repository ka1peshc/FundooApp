using FundooModels;
using FundooRepository;
using FundooRepository.Repository;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<string> ForgotPassword(string email)
        {
            try
            {
                //SendEmail(email);
                return await this.repository.ForgotPassword(email);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
