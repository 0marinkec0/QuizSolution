using Microsoft.AspNetCore.Mvc;
using Quiz.Application.Common.Interfaces;
using Quiz.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz.UI.Controllers
{
    public class AuthController : Controller
    {
        private readonly IIdentityService _identityService;

        public AuthController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            var result = await _identityService.Register(model);

            if (!result.Successfull)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var result = await _identityService.Login(model);

            if (!result.Successfull)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
