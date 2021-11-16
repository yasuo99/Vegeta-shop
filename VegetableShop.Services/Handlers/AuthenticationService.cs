using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OtpNet;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using VegetableShop.DataAccess;
using VegetableShop.Domain.DTOs.Identity;
using VegetableShop.Domain.Models;
using VegetableShop.Services.Interfaces;

namespace VegetableShop.Services.Handlers
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly Random _random;
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _db;
        public AuthenticationService()
        {
            _random = new Random();
        }

        public bool CheckValidOTP(string otp)
        {
            throw new NotImplementedException();
        }

        public string GenerateEmailOTP(string emailAddress)
        {
            var emailConvertToByte = Base32Encoding.ToBytes(emailAddress);
            var totp = new Totp(emailConvertToByte);
            var result = totp.ComputeTotp();
            var remainingTime = totp.RemainingSeconds();
            return result;
        }

        public string GeneratePhoneOTP(string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GenerateToken(LoginDTO loginDTO)
        {
            Account account = await _db.Accounts.AsNoTracking().Where(acc => acc.Email.ToLower().Equals(loginDTO.Username.ToLower()) || acc.UserName.ToLower().Equals(loginDTO.Username.ToLower())).FirstOrDefaultAsync();
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, account.Id.ToString()),
                new Claim(ClaimTypes.Name, account.UserName),
                new Claim(ClaimTypes.Email, account.Email),
                new Claim(ClaimTypes.MobilePhone, account.PhoneNumber)
            };
            foreach(var role in account.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Role.Name));
            }
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration.GetSection("Secret:Token_Key").Value));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = credentials,
                Expires = DateTime.Now.AddHours(8)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(securityToken);
        }

        public int GetRemainTimeOfOTP(string otp)
        {
            return 1;
        }
    }
}
