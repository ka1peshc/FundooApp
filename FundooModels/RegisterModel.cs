using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FundooModels
{
    public class RegisterModel
    {
        [Required]
        [RegularExpression(@"[A-Z]{1}[a-z]{2,}", ErrorMessage = "FirstName is not valid. Please Enter valid first name")]
        public string FirstName { get; set; }
        [Required]
        [RegularExpression(@"[A-Z]{1}[a-z]{2,}", ErrorMessage = "LastName is not valid. Please Enter valid last name")]
        public string LastName { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$", ErrorMessage = "E-mail is not valid. Please Enter valid email")]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^((?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%^&*`~_+]).{8,20})$", ErrorMessage = "Password must include Capital letter special character")]
        public string Password { get; set; }
        [Key]
        public int UserID { get; set; }
    }
}
