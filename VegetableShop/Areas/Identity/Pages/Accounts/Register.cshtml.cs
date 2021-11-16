using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VegetableShop.Domain.Constants;
using VegetableShop.Domain.DTOs.Identity;
using VegetableShop.Domain.Models;
using VegetableShop.Extensions;

namespace VegetableShop.Areas.Identity.Pages.Accounts
{
    [BindProperties]
    public class RegisterModel : PageModel
    {
        private readonly UserManager<Account> _userManager;
        private readonly INotyfService _notyf;
        public RegisterModel(UserManager<Account> userManager, INotyfService notyf)
        {
            _userManager = userManager;
            _notyf = notyf;
        }
        public RegisterDTO RegisterDTO { get; set; }
        public void OnGet()
        {
            RegisterDTO = new RegisterDTO();
        }
        public async Task<IActionResult> OnPost()
        {
            if (Request.IsAjaxRequest())
            {
                if(RegisterDTO.Counter == 0)
                {
                    RegisterDTO.IsValidOTP = true;
                }
                if(RegisterDTO.Counter == 1)
                {
                    RegisterDTO.IsValidEmail = true;
                }
                RegisterDTO.Counter++;
                return Partial("_RegisterFormPartial", RegisterDTO);
            }
            var account = new Account
            {
                UserName = RegisterDTO.Username,
                Email = RegisterDTO.Email,
                FirstName = RegisterDTO.Info.FirstName,
                LastName = RegisterDTO.Info.LastName,
                MiddleName = RegisterDTO.Info.MiddleName,
                PhoneNumber = RegisterDTO.PhoneNumber
            };
            var result = await _userManager.CreateAsync(account, RegisterDTO.Password);
            if (result.Succeeded)
            {
                var addRoleResult = await _userManager.AddToRoleAsync(account, IdentityConstant.CustomerRole);
                if (addRoleResult.Succeeded)
                {
                    _notyf.Success("Signup succeeded");
                    return RedirectToPage("Login");
                }
            }
            _notyf.Error("Signup fail");
            return Page();
        }
    }
}
