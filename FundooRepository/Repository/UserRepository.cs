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
                        //later encryp
                        //userData.Password = this.EncryptPassword(userData.Password);
                        userData.Password = userData.Password;
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
    }
}
