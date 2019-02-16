using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuentasClaras.Model
{
    public class ContextInitializer
    {
        public static async Task Init(IServiceProvider services)
        {

            var _context = services.GetRequiredService<CuentasClarasContext>();
            var _userManager = services.GetRequiredService<UserManager<IdentityUser>>();
            var _roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            _context.Database.EnsureCreated();

            if (_context.Users.Any())
                return;

            string[] roles = new string[] { "Admnistrator", "Editor" };
            var admin = new IdentityUser
            {
                Email = "jonathan.amigo.torres@gmail.com",
                NormalizedEmail = "jonathan.amigo.torres@gmail.com".ToUpper(),
                UserName = "jonathan.amigo.torres@gmail.com",
                NormalizedUserName = "jonathan.amigo.torres@gmail.com".ToUpper(),
                EmailConfirmed = true,
            };

            await CreateRoles(_roleManager, roles);
            await CreateAdminUser(_userManager, admin);
            await AssignRoles(_userManager, admin.Email, roles);
        }

        private static async Task CreateRoles(RoleManager<IdentityRole> roleManager, String[] roles)
        {
            foreach (string role in roles)
            {
                var rol = await roleManager.FindByNameAsync(role);
                if (rol == null)
                    await roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        private static async Task CreateAdminUser(UserManager<IdentityUser> userManager, IdentityUser user)
        {
            await userManager.CreateAsync(user, "TestPassword@123456");
        }

        public static async Task AssignRoles(UserManager<IdentityUser> userManager, string email, string[] roles)
        {
            IdentityUser user = await userManager.FindByEmailAsync(email);
            await userManager.AddToRolesAsync(user, roles);
        }
    }
}
