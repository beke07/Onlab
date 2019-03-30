using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Onlab.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Onlab.Dal
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Image> Images { get; set; }
    }
}
