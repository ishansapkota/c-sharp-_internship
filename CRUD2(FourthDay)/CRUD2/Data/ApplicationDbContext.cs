using CRUD2.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Movies>Movies { get; set; }
    }
}
