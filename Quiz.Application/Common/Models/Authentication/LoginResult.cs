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

        public LoginResult(bool successfull, string token, string error = null)
        {
            Successfull = successfull;
            Token = token;
            Error = error;
        }

        public static LoginResult Success(string token)
        {
            return new LoginResult (true, token, string.Empty);
        }

        public static LoginResult Faliure(string error)
        {
            return new LoginResult(false, string.Empty, error);
        }
    }
}
