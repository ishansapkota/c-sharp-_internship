using Hl7.Fhir.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SHG.Models;



namespace SHGAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PatientController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFhirPatient(string id)
        {
            var patientData = await _context.Patients.FirstOrDefaultAsync(p => p.PatientId == id);

            if (patientData == null)
            {
                return NotFound();
            }

            var fhirPatient = FhirConverter.ConvertToFhirPatient(patientData);

            // Serialize to JSON in FHIR-compliant format
            return Content(fhirPatient.ToJson(), "application/fhir+json");
        }

        [HttpGet("all-patients")]
        public async Task<IActionResult> GetAllPatients()
        {
            var patients = await _context.Patients.ToListAsync();

            if (patients == null || !patients.Any())
            {
                return NotFound();
            }

            var fhirPatients = patients.Select(patient => FhirConverter.ConvertToFhirPatient(patient)).ToList();

            var fhirJsonSerializer = new FhirJsonSerializer(new SerializerSettings() { Pretty = true });
            var jsonFhirPatients = fhirPatients.Select(fhirPatient => fhirJsonSerializer.SerializeToString(fhirPatient)).ToList();

            return Ok(jsonFhirPatients);
        }

        [HttpGet("practitioners")]
        public async Task<IActionResult> GetAllFhirPractitioners()
        {
            var allPractitionerData = await _context.Users.ToListAsync();

            if (allPractitionerData == null || allPractitionerData.Count == 0)
            {
                return NotFound();
            }


            var fhirPractitioners = new List<Hl7.Fhir.Model.Practitioner>();
            foreach (var practitionerData in allPractitionerData)
            {
                var fhirPatient = FhirConverter.ConvertToFhirPractitioner(practitionerData);
                fhirPractitioners.Add(fhirPatient);
            }

            var fhirJsonSerializer = new FhirJsonSerializer();
            var serializedPractitioners = new List<string>();

            foreach (var practitioner in fhirPractitioners)
            {
                var serializedPractitioner = fhirJsonSerializer.SerializeToString(practitioner);
                serializedPractitioners.Add(serializedPractitioner);
            }

            string jsonArray = "[" + string.Join(",", serializedPractitioners) + "]";

            return Content(jsonArray, "application/fhir+json");
        }
    }
}
