using DataAccess_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess_Layer.DTOs
{
    public class DiagnosticReportDTO
    {
        public int Id { get; set; }

        public string Description { get; set; } = null!;

        public int PatientId { get; set; }

        public int EncounterId { get; set; }

        public int? CreatedBy { get; set; }

        public int? UpdatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }

        public int? DeletedBy { get; set; }

        public string? IcdCode { get; set; }

        public virtual User? CreatedByNavigation { get; set; }

        public virtual Encounter Encounter { get; set; } = null!;

        public virtual PatientData Patient { get; set; } = null!;

        public virtual User? UpdatedByNavigation { get; set; }
    }
}
