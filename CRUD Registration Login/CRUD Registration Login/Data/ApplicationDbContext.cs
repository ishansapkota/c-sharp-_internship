using CRUD_Registration_Login.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Registration_Login.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
           
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Goods>Goods { get; set; }
    }
}

