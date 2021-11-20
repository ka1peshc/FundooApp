using FundooModels;
using Microsoft.Extensions.Configuration;

namespace FundooRepository.Repository
{
    public interface IUserRepository
    {
        IConfiguration Configuration { get; }

        string Register(RegisterModel userData);

        string Login(LoginModel userData);
        string ResetPasswrod(ResetPasswordModel userData);
        string EncryptPassword(string password);
    }
}