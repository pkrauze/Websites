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

    public DbSet<Website> Websites { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
