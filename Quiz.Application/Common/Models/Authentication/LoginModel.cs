using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Application.Common.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "E-mail is required.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string  Password { get; set; }
    }
}
