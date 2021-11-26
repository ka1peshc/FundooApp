using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FundooModels;
using FundooRepository.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;


namespace FundooManager.Manager
{
    public class UserManager : IUserManager
    {
        //Declaring obj for the IUserRepository
        private readonly IUserRepository repository;

        public UserManager(IUserRepository repository,IConfiguration configuration)
        {
            this.repository = repository;
            this.Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        
        /// <summary>
        /// Creating new user
        /// </summary>
        /// <param name="userData"></param>
        /// <returns></returns>
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
