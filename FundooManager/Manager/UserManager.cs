using FundooModels;
using FundooRepository.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooManager.Manager
{
    public class UserManager
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
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
