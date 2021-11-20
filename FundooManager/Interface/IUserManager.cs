﻿using FundooModels;

namespace FundooManager.Manager
{
    public interface IUserManager
    {
        string Register(RegisterModel userData);
        string Login(LoginModel userData);

        string ResetPassword(ResetPasswordModel userData);
        string ForgotPassword(string email);
        void SendEmail(string email);
    }
}