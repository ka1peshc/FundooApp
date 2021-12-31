// <copyright file="UserManager.cs" company="JoyBoy">
// Copyright (c) JoyBoy. All rights reserved.
// </copyright>

namespace FundooManager.Manager
{
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    using FundooModels;
    using FundooRepository.Repository;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;

    /// <summary>
    /// Connect controller with repository
    /// </summary>
    public class UserManager : IUserManager
    {
        /// <summary>
        /// private declaration of UserRepository
        /// </summary>
        private readonly IUserRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserManager"/> class
        /// </summary>
        /// <param name="repository">UserRepository</param>
        /// <param name="configuration">Configuration</param>
        public UserManager(IUserRepository repository, IConfiguration configuration)
        {
            this.repository = repository;
            this.Configuration = configuration;
        }

        /// <summary>
        /// Gets configuration from project file
        /// </summary>
        public IConfiguration Configuration { get; }
        
        /// <summary>
        /// Creating new user
        /// </summary>
        /// <param name="userData">RegisterModel</param>
        /// <returns>http response</returns>
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
        /// <returns>http response</returns>
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
        /// <returns>http response</returns>
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

        /// <summary>
        /// Getting email to pass token
        /// </summary>
        /// <param name="email">String email</param>
        /// <returns>http response</returns>
        public async Task<string> ForgotPassword(string email)
        {
            try
            {
                return await this.repository.ForgotPassword(email);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Generating token
        /// </summary>
        /// <param name="email">string email</param>
        /// <returns>http response</returns>
        public string GenerateToken(string email)
        {
            byte[] key = Encoding.UTF8.GetBytes(this.Configuration["Secret"]);
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);
            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, email) }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
            };
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken token = handler.CreateJwtSecurityToken(descriptor);
            return handler.WriteToken(token);
        }
    }
}
