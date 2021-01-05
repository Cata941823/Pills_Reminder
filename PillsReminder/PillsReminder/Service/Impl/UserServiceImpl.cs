using PillsReminder.Entities;
using PillsReminder.Repository;
using PillsReminder.Helpers;
using PillsReminder.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using PillsReminder.Mapper;

namespace PillsReminder.Service.Impl
{
    public class UserServiceImpl : UserService
    {
        private readonly UserRepository userRepository;
        private readonly AppSettings appSettings;

        public UserServiceImpl(UserRepository userRepository, IOptions<AppSettings> options)
        {
            this.userRepository = userRepository;
            this.appSettings = options.Value;
        }

        public AuthenticationResponse Login(AuthenticationRequest request)
        {
            // Get user from database
            var user = userRepository.GetByEmailAndPassword(request.Email, request.Password);
            if (user == null)
                return null;

            // Generate JWT Token
            var token = GenerateJwtToken(user);

            return new AuthenticationResponse
            {
                Id = user.Id,
                Email = user.Email,
                Token = token
            };
        }

        public bool Register(RegisterRequest request)
        {
            var user = request.ToUserExtension();
            userRepository.Create(user);
            userRepository.SaveChanges();
            return true;
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
