using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Hl7.Fhir.Rest;
using Hl7.Fhir.Model;

namespace FHIR_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FHIR : ControllerBase
    {
        private const string FhirServer = "https://server.fire.ly";

        [HttpGet]
        public IActionResult GetPatients()
        { 

            try
            {
                FhirClient fhirClient = new FhirClient(FhirServer);
                Bundle patientBundle = fhirClient.Search<Patient>(new string[] { });

                var patients = new List<object>();

                    foreach (Bundle.EntryComponent patientEntry in patientBundle.Entry)
                    {
                        if (patientEntry.Resource != null)
                        {
                            Patient patient = (Patient)patientEntry.Resource;
                            patients.Add(new
                            {
                                Id = patient.Id,
                                Name = patient.Name[0].ToString(),
                                Address = patient.Address,
                                MaritalStatus = patient.MaritalStatus,
                                Language = patient.Language
                            });
                        }
                    }  

                return Ok(new
                {
                    Total = patients.Count,
                    Patients = patients
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }
    }
}
