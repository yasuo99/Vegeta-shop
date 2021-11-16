using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegetableShop.Domain.Constants;
using VegetableShop.Domain.Models;

namespace VegetableShop.Data
{
    public static class Seeder
    {
        public static void SeedRole(RoleManager<Role> roleManager)
        {
            if (!roleManager.RoleExistsAsync(IdentityConstant.AdminRole).GetAwaiter().GetResult())
            {
                roleManager.CreateAsync(new Role
                {
                    Name = IdentityConstant.AdminRole
                }).GetAwaiter().GetResult();
            }
            if (!roleManager.RoleExistsAsync(IdentityConstant.ManagerRole).GetAwaiter().GetResult())
            {
                roleManager.CreateAsync(new Role
                {
                    Name = IdentityConstant.ManagerRole
                }).GetAwaiter().GetResult();
            }
            if (!roleManager.RoleExistsAsync(IdentityConstant.ProviderRole).GetAwaiter().GetResult())
            {
                roleManager.CreateAsync(new Role
                {
                    Name = IdentityConstant.ProviderRole
                }).GetAwaiter().GetResult();
            }
            if (!roleManager.RoleExistsAsync(IdentityConstant.TechnicalRole).GetAwaiter().GetResult())
            {
                roleManager.CreateAsync(new Role
                {
                    Name = IdentityConstant.TechnicalRole
                }).GetAwaiter().GetResult();
            }
            if (!roleManager.RoleExistsAsync(IdentityConstant.CustomerRole).GetAwaiter().GetResult())
            {
                roleManager.CreateAsync(new Role
                {
                    Name = IdentityConstant.CustomerRole
                }).GetAwaiter().GetResult();
            }

        }
        public static void SeedAccount(UserManager<Account> userManager, RoleManager<Role> roleManager)
        {

            if (userManager.FindByNameAsync("Admin").GetAwaiter().GetResult() == null)
            {
                var account = new Account
                {
                    UserName = "Admin",
                    Email = "yasuo12091999@gmail.com"
                };
                var result = userManager.CreateAsync(account, "Thanhpro1@").GetAwaiter().GetResult();
                if (result.Succeeded)
                {
                    if (!roleManager.RoleExistsAsync(IdentityConstant.AdminRole).GetAwaiter().GetResult())
                    {
                        SeedRole(roleManager);
                    }
                    else
                    {
                        userManager.AddToRoleAsync(account, IdentityConstant.AdminRole).GetAwaiter().GetResult();
                    }
                }
            }
            if (userManager.FindByNameAsync("Manager").GetAwaiter().GetResult() == null)
            {
                var account = new Account
                {
                    UserName = "Manager",
                    Email = "yasuo120999@gmail.com"
                };
                var result = userManager.CreateAsync(account, "Thanhpro1@").GetAwaiter().GetResult();
                if (result.Succeeded)
                {
                    if (!roleManager.RoleExistsAsync(IdentityConstant.ManagerRole).GetAwaiter().GetResult())
                    {
                        SeedRole(roleManager);
                    }
                    else
                    {
                        userManager.AddToRoleAsync(account, IdentityConstant.ManagerRole).GetAwaiter().GetResult();
                    }
                }

            }
        }
    }
}
