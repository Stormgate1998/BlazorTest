
using Microsoft.AspNetCore.Identity;

namespace BlazorApp1.Services
{
    public class Userservice
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;


        public Userservice(UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task AddUser(string id, string name, string email)
        {
            var existingUser = await userManager.FindByEmailAsync(email);

            //ensure the role exists
            var userRole = await roleManager.FindByNameAsync("user");
            if (userRole == null)
            {
                userRole = new IdentityRole { Name = "user" };
                var result = await roleManager.CreateAsync(userRole);
                if (result.Succeeded == false)
                {
                    throw new Exception(String.Join(", ", result.Errors.Select(e => e.Description)));
                }
            }

            //if user not in role "artists", add to role
            if (await userManager.IsInRoleAsync(existingUser, "user") == false)
            {
                await userManager.AddToRoleAsync(existingUser, "user");
            }
        }
    }
}
