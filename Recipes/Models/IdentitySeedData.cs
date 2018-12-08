using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

/*
 * Course: COMP229-001-Project-v1
 * Group#: 9
 * Members: Asha Saha, Janelle Baetiong, Youngshin Min
 */

namespace Recipes.Models
{
    public class IdentitySeedData
    {
        private const string adminUser = "Admin";
        private const string adminPassword = "Secret123$";
        private const string adminUser2 = "Admin2";
        private const string adminPassword2 = "Secret123$2";
        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            UserManager<IdentityUser> userManager = app.ApplicationServices
            .GetRequiredService<UserManager<IdentityUser>>();
            IdentityUser user = await userManager.FindByIdAsync(adminUser);
            if (user == null)
            {
                user = new IdentityUser("Admin");
                await userManager.CreateAsync(user, adminPassword);

            }

            IdentityUser user2 = await userManager.FindByIdAsync(adminUser2);
            if (user2 == null)
            {
                user2 = new IdentityUser("Admin2");
                await userManager.CreateAsync(user2, adminPassword2);

            }
        }

    }
}
