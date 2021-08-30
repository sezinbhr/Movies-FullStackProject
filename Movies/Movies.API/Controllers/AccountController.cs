﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Movies.API.Models;
using Movies.Business;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Movies.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IUserService userService;
        private IConfiguration configuration;

        public AccountController(IUserService userService, IConfiguration configuration )
        {
            this.userService = userService;
            this.configuration = configuration;
        }
        [HttpPost]
        public IActionResult Login(UserLoginModel userLoginModel)
        {
            var user = userService.GetUser(userLoginModel.Email, userLoginModel.Password);
            if (user == null)
            {
                return BadRequest(new  {message = "Invalid password or email address!" });
            }

            string issuer = "kodluyoruz.com";
            string audience = "kodluyoruz.com";

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.userName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(ClaimTypes.Role, user.userRole)


            };


            var key = configuration.GetSection("Bearer")["SecurityKey"];
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddHours(1.5),
                signingCredentials: credential

                );

            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        }
    }
}
