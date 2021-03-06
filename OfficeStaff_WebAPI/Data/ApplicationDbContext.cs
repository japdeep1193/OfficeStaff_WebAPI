using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OfficeStaff_WebAPI.Models;

namespace OfficeStaff_WebAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<OfficeStaff> OfficeStaffs { get; set; }
        public DbSet<OfficeClients> OfficeClients { get; set; }
    }
}
