using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace WebsitesProject.Models.ApplicationRoleViewModels
{
    public class ApplicationRoleListViewModel
    {
        public string Id { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
    }
}
