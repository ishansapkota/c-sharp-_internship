using System.ComponentModel.DataAnnotations;

namespace FHIR_API.DataAccess
{
    public class PractitionerDetails
    {
        [Key]
        public string Id { get; set; }

        public bool Active { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Gender { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Fax { get; set; }
        public List<string>? Qualification { get; set; }

    }
}
