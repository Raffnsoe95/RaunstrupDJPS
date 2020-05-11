using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Raunstrup.UI.UserManagement
{
    public class UserManagementDbInitializer
    {
        internal static async Task InitializeAsync(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            // Set password with the Secret Manager tool.
            // dotnet user-secrets set SeedUserPW <pw>

            var adminUserEmail = configuration["AdminUserEmail"];
            var adminUserPw = configuration["AdminUserPw"];
            await using var context = serviceProvider.GetRequiredService<UserManagementContext>();

            var adminId = await EnsureUserAsync(serviceProvider, adminUserEmail, adminUserPw).ConfigureAwait(false);
            await EnsureRoleAsync(serviceProvider, adminId, "Admin").ConfigureAwait(false);

            var superUserEmail = configuration["SuperUserEmail"];
            var superUserPw = configuration["SuperUserPw"];
            var superUserId = await EnsureUserAsync(serviceProvider, superUserEmail, superUserPw).ConfigureAwait(false);
            await EnsureRoleAsync(serviceProvider, superUserId, "SuperUser").ConfigureAwait(false);

            var userEmail = configuration["UserEmail"];
            var userPw = configuration["UserPw"];
            var userId = await EnsureUserAsync(serviceProvider, userEmail, userPw).ConfigureAwait(false);
            await EnsureRoleAsync(serviceProvider, userId, "User").ConfigureAwait(false);

            var userId8 = await EnsureUserAsync(serviceProvider, "8@bruger.com", "bruger8").ConfigureAwait(false);
            await EnsureRoleAsync(serviceProvider, userId8, "SuperUser").ConfigureAwait(false);

            var userId1 = await EnsureUserAsync(serviceProvider,"1@bruger.com", "bruger1").ConfigureAwait(false);
            await EnsureRoleAsync(serviceProvider, userId1, "User").ConfigureAwait(false);

            var userId2 = await EnsureUserAsync(serviceProvider, "2@bruger.com", "bruger2").ConfigureAwait(false);
            await EnsureRoleAsync(serviceProvider, userId2, "User").ConfigureAwait(false);
        }

        private static async Task<string> EnsureUserAsync(IServiceProvider serviceProvider,
            string userName, string userPw)
        {
            var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();

            var user = await userManager.FindByNameAsync(userName).ConfigureAwait(false);
            if (user == null)
            {
                user = new IdentityUser
                {
                    UserName = userName,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(user, userPw).ConfigureAwait(false);
            }

            if (user == null) throw new Exception("The password is probably not strong enough!");

            return user.Id;
        }

        private static async Task EnsureRoleAsync(IServiceProvider serviceProvider,
            string uid, string role)
        {
            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

            if (roleManager == null) throw new Exception("roleManager null");

            if (!await roleManager.RoleExistsAsync(role).ConfigureAwait(false))
                await roleManager.CreateAsync(new IdentityRole(role)).ConfigureAwait(false);

            var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();

            var user = await userManager.FindByIdAsync(uid).ConfigureAwait(false);

            if (user == null) throw new Exception("The testUserPw password was probably not strong enough!");

            await userManager.AddToRoleAsync(user, role).ConfigureAwait(false);
        }
    }
}
