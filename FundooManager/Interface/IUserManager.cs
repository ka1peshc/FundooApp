using FundooModels;
using System.Threading.Tasks;

namespace FundooManager.Manager
{
    public interface IUserManager
    {
        string Register(RegisterModel userData);
        string Login(LoginModel userData);
        string ResetPassword(ResetPasswordModel userData);
        Task<string> ForgotPassword(string email);
        string GenerateToken(string email);
    }
}