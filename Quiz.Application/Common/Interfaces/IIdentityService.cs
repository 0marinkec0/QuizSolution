using Quiz.Application.Common.Models;
using Quiz.Application.Common.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Application.Common.Interfaces
{
    public interface IIdentityService
    {
         Task<RegisterResult> Register(RegisterModel model);
         Task<LoginResult> Login(LoginModel model);
    }
}
