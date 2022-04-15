using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Application.Common.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Username is required.")]
        public string UserName { get; set; }

        [EmailAddress(ErrorMessage = "E-mail is invalid")]
        [Required(ErrorMessage = "E-mail is required.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
