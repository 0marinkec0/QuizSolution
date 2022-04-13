using Microsoft.AspNetCore.Identity;
using Quiz.Application.Common.Interfaces;
using Quiz.Application.Common.Models;
using Quiz.Application.Common.Models.Authentication;
using Quiz.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Interface.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public IdentityService(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<LoginResult> Login(LoginModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
                return new LoginResult() { Successfull = false, Error = "Invalid username or password" };

            var signInResult = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);

            if (!signInResult.Succeeded)
                return new LoginResult() { Successfull = false, Error = await signInResult.SignInResultErrorAsync(user, _userManager)};

            return new LoginResult() { Successfull = true };
        }

        public async Task<RegisterResult> Register(RegisterModel model)
        {
            var user = new User
            {
                Email = model.Email,
                UserName = model.UserName
            };

            var identityResult = await _userManager.CreateAsync(user, model.Password);

            if (identityResult.Succeeded)
                return RegisterResult.Success();
            // return new RegisterResult() { Successfull = true };

            return RegisterResult.Failure(identityResult.Errors.Select(e => e.Description));
            //return new RegisterResult() { Successfull = false, Errors = identityResult.Errors.Select(e => e.Description).ToArray() };
        }
    }
}
