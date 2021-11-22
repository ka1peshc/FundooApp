using FundooModels;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace FundooRepository.Repository
{
    public interface IUserRepository
    {
        IConfiguration Configuration { get; }

        string Register(RegisterModel userData);

        string Login(LoginModel userData);
        string ResetPasswrod(ResetPasswordModel userData);
        string EncryptPassword(string password);
        Task<string> ForgotPassword(string email);
    }
}