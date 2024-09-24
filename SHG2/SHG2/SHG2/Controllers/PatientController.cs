using DataAccess_Layer.Models;
using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using Infrastructure_Layer;

namespace SHG2.Controllers
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

        

            var fhirPractitioners = new List<Practitioner>();
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

        [HttpGet("diagnostic-report")]
        public async Task<IActionResult> GetAllDiagnosticReport()
        {
            var fhirConverterObj = new FhirConverter(_context);
            var alldiagnosticReport = await _context.ConfirmDiagnoses.ToListAsync();
           // var allencountersData = await _context.Encounters.ToListAsync();
            if(alldiagnosticReport == null || alldiagnosticReport.Count == 0)
            {
                return NotFound();
            }

            var fhirDiagnoses = new List<DiagnosticReport>();
            foreach(var diagnosticReport in alldiagnosticReport)
            {
                var fhirDiagnosis = fhirConverterObj.ConvertToFhirDiagnosticReport(diagnosticReport);
                fhirDiagnoses.Add(fhirDiagnosis);
            }

            var fhirJsonSerializer = new FhirJsonSerializer();
            var serializedDiagnosticReports = new List<string>();

            foreach(var report in  fhirDiagnoses)
            {
                var serializedReport = fhirJsonSerializer.SerializeToString(report);
                serializedDiagnosticReports.Add(serializedReport);
            }
            string jsonArray = "[" + string.Join(",", serializedDiagnosticReports) + "]";

            return Content(jsonArray, "application/fhir+json");
        }

        [HttpGet("medication")]
        public async Task<IActionResult> GetAllMedications()
        {
            var fhirConverterObj = new FhirConverter(_context);
            var allMedications = await _context.Medications.ToListAsync();
            // var allencountersData = await _context.Encounters.ToListAsync();
            if (allMedications == null || allMedications.Count == 0)
            {
                return NotFound();
            }

            var fhirMedications = new List<Medication>();
            foreach (var medication in allMedications)
            {
                var fhirMedication = fhirConverterObj.ConvertToFhirMedication(medication);
                fhirMedications.Add(fhirMedication);
            }

            var fhirJsonSerializer = new FhirJsonSerializer();
            var serializedMedications = new List<string>();

            foreach (var med in fhirMedications)
            {
                var serializedMedication = fhirJsonSerializer.SerializeToString(med);
                serializedMedications.Add(serializedMedication);
            }
            string jsonArray = "[" + string.Join(",", serializedMedications) + "]";

            return Content(jsonArray, "application/fhir+json");
        }
    }
}