using Core.DTOs;
using Core.Helpers;
using Core.Interfaces;
using Core.Resources;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    internal class AccountService : IAccountService
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountService(UserManager<IdentityUser> userManager, 
                              SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public async Task RegisterAsync(RegisterDTO userData)
        {
            var user = new IdentityUser()
            {
                Email = userData.Email,
                UserName = userData.Email,
                PhoneNumber = userData.PhoneNumber
            };

            var result = await userManager.CreateAsync(user, userData.Password);

            if (!result.Succeeded)
            {
                string message = string.Join(' ', result.Errors.Select(e => e.Description));

                //StringBuilder errroBuilder = new StringBuilder();

                //foreach (var error in result.Errors)
                //{
                //    errroBuilder.AppendLine(error.Description);
                //}

                throw new HttpException(System.Net.HttpStatusCode.BadRequest, message);
            }
        }
        public Task Login(string login, string password)
        {
            throw new NotImplementedException();
        }

        public Task Logout()
        {
            throw new NotImplementedException();
        }
    }
}
