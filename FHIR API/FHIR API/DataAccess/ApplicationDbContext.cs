using Microsoft.EntityFrameworkCore;

namespace FHIR_API.DataAccess
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base (options)
        {
            
        }

        public DbSet<PatientDetail> Patients { get; set; }
        public DbSet<PractitionerDetails>Practioners { get; set; } 
    }
}
