using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebsitesProject.Models;

namespace WebsitesProject.Data
{
    public class ApplicationDbInitializer
    {
        private readonly WebsitesContext _context;
        private readonly UserManager<User> _userManager;

        public ApplicationDbInitializer(WebsitesContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public void Seed()
        {
            _context.Database.Migrate();

            string adminRoleName = "Admin";
            string userRoleName = "User";

            if (!_context.Roles.Any())
            {
                var roleNames = new[]
                {
                    "Admin",
                    "User"
                };

                foreach (var roleName in roleNames)
                {
                    var role = new IdentityRole(roleName) { NormalizedName = roleName.ToUpper() };
                    _context.Roles.Add(role);
                }
            }

            if (!_context.User.Any())
            {
                //Add admin account
                var admin = new User { UserName = "admin@example.com", Email = "admin@example.com" };
                _userManager.CreateAsync(admin, "Password1").Wait();
                _userManager.AddToRoleAsync(admin, adminRoleName).Wait();

                //Add user account
                var user = new User { UserName = "user@example.com", Email = "user@example.com" };
                _userManager.CreateAsync(user, "Password1").Wait();
                _userManager.AddToRoleAsync(user, userRoleName).Wait();
            }

            _context.SaveChanges();
        }
    }
}