using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD.Models;

namespace CRUD.Data
{
    public class MVCDemoDbContext : DbContext //This DbContext comes from Entity Framework Core
    {
        public MVCDemoDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<FootballerDetails> FootballerDetails { get; set; }
    }
}
