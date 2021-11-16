using FundooModels;
using FundooRepository.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooManager.Manager
{
    //Declaring obj for the IUserRepository
    private readonly IUserRepository repository;
    public class UserManager
    {
        //register pass the user data to the repository
        public string Register(RegisterModel userData)
        {
            try
            {
                return this.repository.Register(userData);
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
