using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Application.Common.Models.Authentication
{
    public class LoginResult
    {
        public bool Successfull { get; set; }
        public string Token { get; set; }
        public string Error { get; set; }
    }
}
