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

    public DbSet<Website> Website { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<User> User { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
