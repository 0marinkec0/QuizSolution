using Quiz.Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Quiz.UI.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContexAccessor)
        {
            UserId = Convert.ToInt32(httpContexAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier));
            UserName = httpContexAccessor.HttpContext?.User?.FindFirstValue("UserName");
        }

        public int UserId { get; }
        public string UserName { get; }
    }
}
