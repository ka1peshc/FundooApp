// <copyright file="UserController.cs" company="JoyBoy">
// Copyright (c) JoyBoy. All rights reserved.
// </copyright>

namespace FundooNotes.Controllers
{
    using System;
    using System.Threading.Tasks;
    using FundooManager.Manager;
    using FundooModels;
    using Microsoft.AspNetCore.Mvc;
    using NLog;
    using StackExchange.Redis;

    /// <summary>
    /// Handle Request and give response related to user login and signup
    /// </summary>
    public class UserController : Controller
    {
        /// <summary>
        /// Private declaration of UserManager
        /// </summary>
        private readonly IUserManager manager;

        /// <summary>
        /// Private declaration of Logger class
        /// </summary>
        //private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/>
        /// </summary>
        /// <param name="log">Logger</param>
        /// <param name="manager">UserManager</param>
        //public UserController(ILogger log, IUserManager manager)
        //{
        //    this.logger = log;
        //    this.manager = manager;
        //}
        public UserController(IUserManager manager)
        {
            this.manager = manager;
        }
        /// <summary>
        /// Create new user
        /// </summary>
        /// <param name="userData">RegisterModel</param>
        /// <returns>http response</returns>
        [HttpPost]
        [Route("api/register")]
        public IActionResult Register([FromBody]RegisterModel userData)
        {
            try
            {
                string result = this.manager.Register(userData);
                if (result.Equals("Registration Successful"))
                {
                    //this.logger.Info(result + Environment.NewLine + DateTime.Now);
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result, Data = " Session data" });
                }
                else
                {
                    //this.logger.Warn(result + Environment.NewLine + DateTime.Now);
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                //this.logger.Error(ex.Message + Environment.NewLine + DateTime.Now);
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// check user login credential
        /// </summary>
        /// <param name="userData">LoginModel</param>
        /// <returns>Http response</returns>
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
                    int userId = Convert.ToInt32(database.StringGet("User Id"));
                    RegisterModel data = new RegisterModel
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        UserID = userId,
                        Email = userData.Email
                    };
                    string tokenString = this.manager.GenerateToken(userData.Email);
                    //this.logger.Info(result + Environment.NewLine + DateTime.Now);
                    return this.Ok(new { Status = true, Message = result, Data = data, Token = tokenString });
                }
                else
                {
                    //this.logger.Warn(result + Environment.NewLine + DateTime.Now);
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                //this.logger.Error(ex.Message + Environment.NewLine + DateTime.Now);
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Sending reset password api response
        /// </summary>
        /// <param name="userData">ResetPasswordModel</param>
        /// <returns>Http response</returns>
        [HttpPut]
        [Route("api/resetpassword")]
        public IActionResult ResetPassword([FromBody] ResetPasswordModel userData)
        {
            try
            {
                string result = this.manager.ResetPassword(userData);
                if (result.Equals("Password Reset Successful"))
                {
                    //this.logger.Info(result + Environment.NewLine + DateTime.Now);
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result, Data = " Session data" });
                }
                else
                {
                    //this.logger.Warn(result + Environment.NewLine + DateTime.Now);
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                //this.logger.Error(ex.Message + Environment.NewLine + DateTime.Now);
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Call forget api using params where key=email and value=mailid
        /// </summary>
        /// <param name="email">Email in string</param>
        /// <returns>Http response</returns>
        [HttpPost]
        [Route("api/forgotpassword")]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            try
            {
                string result = await this.manager.ForgotPassword(email);
                if (result == "Email send Successfully")
                {
                    //this.logger.Info(result + Environment.NewLine + DateTime.Now);
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result, Data = " Session data" });
                }
                else
                {
                    //this.logger.Warn(result + Environment.NewLine + DateTime.Now);
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                //this.logger.Error(ex.Message + Environment.NewLine + DateTime.Now);
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
    }
}
