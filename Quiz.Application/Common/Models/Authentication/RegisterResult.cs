using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Application.Common.Models.Authentication
{
    public class RegisterResult
    {
        public bool Successfull { get; set; }
        public string[] Errors { get; set; }

        public RegisterResult(bool successfull, IEnumerable<string> errors)
        {
            Successfull = successfull;
            Errors = errors.ToArray();
        }

        public static RegisterResult Success()
        {
            return new RegisterResult(true, Array.Empty<string>());
        }

        public static RegisterResult Failure(IEnumerable<string> errors)
        {
            return new RegisterResult(false, errors);
        }
    }
}
