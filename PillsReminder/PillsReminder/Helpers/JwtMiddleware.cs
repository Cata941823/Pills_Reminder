using PillsReminder.Service;
using PillsReminder.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PillsReminder.Service.Impl;
using PillsReminder.Repository;

namespace PillsReminder.Helpers
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;

        public JwtMiddleware(RequestDelegate del, IOptions<AppSettings> options)
        {
            _next = del;
            _appSettings = options.Value;
        }

        public async Task Invoke(HttpContext context, UserRepository userRepository)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
                AttachUserToContextByToken(context, userRepository, token);

            await _next(context);
        }

        private void AttachUserToContextByToken(HttpContext context, UserRepository userRepository, string token)
        {
            try
            {
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenHandler = new JwtSecurityTokenHandler();
                tokenHandler.ValidateToken(token, new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                }, out SecurityToken securityToken);

                var jwtToken = (JwtSecurityToken)securityToken;
                var userId = int.Parse(jwtToken.Claims.FirstOrDefault(x => x.Type == "id").Value);

                context.Items["User"] = userRepository.FindById(userId);
            }
            catch (Exception)
            {
                
            }
        }
    }
}
