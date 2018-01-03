using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebsitesProject.Models;

public class WebsitesContext : IdentityDbContext<User>
{
    public WebsitesContext (DbContextOptions<WebsitesContext> options)
        : base(options)
    {
    }

    public DbSet<WebsitesProject.Models.Website> Website { get; set; }
    public DbSet<WebsitesProject.Models.Order> Order { get; set; }
    public DbSet<WebsitesProject.Models.User> User { get; set; }
}
