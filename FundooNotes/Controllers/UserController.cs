using FundooManager.Manager;
using FundooModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            //this.logger.LogInformation("Registration of new user initialized");
            //HttpContext.Session.SetString(SessionName, userData.FirstName + " " + userData.LastName);
            //HttpContext.Session.SetString(SessionMail, userData.Email);
            try
            {
                string result = this.manager.Register(userData);
                if(result.Equals("Registration Successful"))
                {
                    //var name = HttpContext.Session.GetString(SessionName);
                    //var email = HttpContext.Session.GetString(SessionMail);
                    //Create a OkResult object that produces an empty Status 200 OK response.
                    //this.logger.LogInformation(userData.FirstName + " is registered");
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result, Data = " Session data" });
                }
                else
                {
                    //this.logger.LogError("Registration unsuccessfull");
                    //Creates an BadRequestResult that produce a Status400 BadRequest response.
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                //this.logger.LogError("Error occurs: " + ex.Message);
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }


        [HttpGet]
        [Route("api/login")]
        public IActionResult Login([FromBody] LoginModel userData)
        {
            try
            {
                string result = this.manager.Login(userData);
                if (result.Equals("Login Successful"))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result, Data = " Session data" });
                }
                else
                {
                    //Creates an BadRequestResult that produce a Status400 BadRequest response.
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

        public IActionResult Index()
        {
            return View();
        }
    }
}
