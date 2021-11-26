using FundooManager.Manager;
using FundooModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{
    public class UserController: Controller
    {
        private readonly IUserManager manager;

        public UserController(IUserManager manager)
        {
            this.manager = manager;
        }

        [HttpPost]
        [Route("api/register")]
        public IActionResult Register([FromBody]RegisterModel userData)
        {
            try
            {
                string result = this.manager.Register(userData);
                if(result.Equals("Registration Successful"))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result, Data = " Session data" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }


        [HttpPost]
        [Route("api/login")]
        public IActionResult Login([FromBody] LoginModel userData)
        {
            try
            {
                string result = this.manager.Login(userData);
                if (result.Equals("Login Successful"))
                {
                    ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect("127.0.0.1:6379");
                    IDatabase database = connectionMultiplexer.GetDatabase();
                    string firstName = database.StringGet("First Name");
                    string lastName = database.StringGet("Last Name");
                    RegisterModel data = new RegisterModel
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        //UserID = userData,
                        Email = userData.Email
                    };
                    string tokenString = this.manager.GenerateToken(userData.Email);
                    //return this.Ok(new ResponseModel<string>() { Status = true, Message = result, Data = " Session data"});
                    return this.Ok(new { Status = true, Message = result, Data = " Session data", Token = tokenString });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Sending reset password api response
        /// </summary>
        /// <param name="userData">ResetPasswordModel</param>
        /// <returns></returns>
        [HttpPut]
        [Route("api/resetpassword")]
        public IActionResult ResetPassword([FromBody] ResetPasswordModel userData)
        {
            try
            {
                string result = this.manager.ResetPassword(userData);
                if (result.Equals("Password Reset Successful"))
                {
                    return this.Ok(new ResponseModel<String>() { Status = true, Message = result, Data = " Session data" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Call forget api using params where key=email and value=mailid
        /// </summary>
        /// <param name="email">Email in string</param>
        /// <returns>api response</returns>
        [HttpPost]
        [Route("api/forgotpassword")]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            try
            {
                string result = await this.manager.ForgotPassword(email);
                if (result == "Email send Successfully")
                {
                    return this.Ok(new ResponseModel<String>() { Status = true, Message = result, Data = " Session data" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
