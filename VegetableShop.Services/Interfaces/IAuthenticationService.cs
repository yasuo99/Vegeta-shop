using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegetableShop.Domain.DTOs.Identity;
using VegetableShop.Domain.Models;

namespace VegetableShop.Services.Interfaces
{
    public interface IAuthenticationService
    {
        string GeneratePhoneOTP(string phoneNumber);
        int GetRemainTimeOfOTP(string otp);
        bool CheckValidOTP(string otp);
        string GenerateEmailOTP(string emailAddress);
        Task<string> GenerateToken(LoginDTO loginDTO);
    }
}
