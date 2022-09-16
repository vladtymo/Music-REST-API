using Core.DTOs;
using Core.Helpers;
using Core.Interfaces;
using Core.Resources;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    internal class AccountService : IAccountService
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IConfiguration configuration;

        public AccountService(UserManager<IdentityUser> userManager, 
                              SignInManager<IdentityUser> signInManager,
                              IConfiguration configuration)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
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

                throw new HttpException(HttpStatusCode.BadRequest, message);
            }
        }
        public async Task<LoginResponse> LoginAsync(string login, string password)
        {
            var user = await userManager.FindByEmailAsync(login);

            if (user == null || !await userManager.CheckPasswordAsync(user, password))
            {
                throw new HttpException(HttpStatusCode.BadRequest, "Invalid login or password.");
            }

            await signInManager.SignInAsync(user, true);

            return new LoginResponse()
            {
                Token = GenerateToken(user)
            };
        }

        private string GenerateToken(IdentityUser user)
        {
            // create claims
            var claims = new ClaimsIdentity(new[]
            {
                new Claim(nameof(user.Id), user.Id),
                new Claim(nameof(user.Email), user.Email)
            });

            // generate token
            var tokenHandler = new JwtSecurityTokenHandler();

            var jwtOptions = configuration.GetSection("JwtOptions").Get<JwtOptions>();
            var key = Encoding.ASCII.GetBytes(jwtOptions.Key);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Issuer = jwtOptions.Issuer,
                Expires = DateTime.UtcNow.AddHours(jwtOptions.Lifetime), // TODO: not working - fix
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task LogoutAsync()
        {
            await signInManager.SignOutAsync();
        }
    }
}
