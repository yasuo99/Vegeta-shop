using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VegetableShop.Domain.DTOs.Identity;
using VegetableShop.Domain.Models;

namespace VegetableShop.Areas.Identity.Pages.Accounts
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<Account> _signInManager;
        private readonly UserManager<Account> _userManager;
        private readonly INotyfService _toastService;

        public LoginModel(SignInManager<Account> signInManager, INotyfService toastService, UserManager<Account> userManager)
        {
            _signInManager = signInManager;
            _toastService = toastService;
            _userManager = userManager;
        }
        [BindProperty]
        public LoginDTO LoginDTO { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                _toastService.Warning("Vui lòng điền đầy đủ thông tin");
                return Page();
            }
            if (LoginDTO.Username.Contains("@"))
            {
                var user = await _userManager.FindByEmailAsync(LoginDTO.Username);
                var result = await _signInManager.CheckPasswordSignInAsync(user, LoginDTO.Password, false);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    _toastService.Success("Welcome");
                    return RedirectToAction("Index", new { area = "Customer", controller = "Home" });
                }
            }
            _toastService.Error("Tài khoản hoặc mật khẩu không chính xác");
            return Page();
        }
        public async Task<IActionResult> OnPostLogout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", new { area = "Customer", controller = "Home" });
        }
    }
}
