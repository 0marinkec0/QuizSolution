using Microsoft.AspNetCore.Identity;
using Quiz.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Interface.Services
{
    public static class IdentityResultExtension
    {
        public static async Task<string> SignInResultErrorAsync(this SignInResult signInResult, User user, UserManager<User> userManager)
        {
            if (signInResult.IsNotAllowed)
            {
                if (!await userManager.IsEmailConfirmedAsync(user))
                    return "E-mail is not confirmed";

                else if (!await userManager.IsPhoneNumberConfirmedAsync(user))
                    return "Phone number is not confirmed";
            }

            if (signInResult.IsLockedOut)
                return "Account is locked out";

            if (signInResult.RequiresTwoFactor)
                return "2 factor authentication required";

            return "Invalid e-mail or password";
        }
    }
}
