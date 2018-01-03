using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebsitesProject.Models;

    public class WebsitesContext : DbContext
    {
        public WebsitesContext (DbContextOptions<WebsitesContext> options)
            : base(options)
        {
        }

        public DbSet<WebsitesProject.Models.Website> Website { get; set; }
        public DbSet<WebsitesProject.Models.Order> Order { get; set; }
    }
