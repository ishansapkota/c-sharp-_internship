using DataAccess_Layer.Models;
using Hl7.Fhir.Model;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure_Layer
{
    public class FhirConverter
    {
        private readonly ApplicationDbContext dbContext;

        public FhirConverter(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        
        public static Patient ConvertToFhirPatient(PatientData data)
        {
            var patient = new Patient
            {
                Id = data.PatientId,
                Name = new List<HumanName>
            {
                new HumanName
                {
                    Text = data.Name
                }
            },
                Gender = data.Gender.ToLower() == "male" ? AdministrativeGender.Male : AdministrativeGender.Female,
                BirthDate = data.Dob?.ToString("yyyy-MM-dd"),
                Telecom = new List<ContactPoint>
            {
                new ContactPoint
                {
                    System = ContactPoint.ContactPointSystem.Phone,
                    Value = data.PhoneNumber
                }
            },
                Address = new List<Address>
            {
                new Address
                {
                    State = data.Province,
                    City = data.District,
                    District = data.Palika,
                    PostalCode = data.Ward.ToString()
                }
            },
                Identifier = new List<Identifier>
            {
                new Identifier
                {
                    System = "https://nationalid.com",
                    Value = data.NationalId
                },
                new Identifier
                {
                    System = "https://nhis.com",
                    Value = data.NhisNumber
                }
            }
            };
            return patient;
        }

        public static Practitioner ConvertToFhirPractitioner(User data)
        {
            var practitioner = new Practitioner
            {
                Id = Convert.ToString(data.Id),
                Name = new List<HumanName>
                {
                    new HumanName
                    {
                        FamilyElement = new FhirString
                        {
                            Value = data.LastName
                        },
                        UseElement = new Code<HumanName.NameUse>
                        {
                            Value = HumanName.NameUse.Official
                        },
                        GivenElement = new List<FhirString>
                        {
                            new FhirString
                            {
                                Value = data.FirstName
                            }
                        }
                    }
                },
                Active = null,
                Telecom = new List<ContactPoint>
                {
                new ContactPoint
                {
                    System = ContactPoint.ContactPointSystem.Phone,
                    Value = data.PhoneNumber,
                },
                new ContactPoint
                {
                     System= ContactPoint.ContactPointSystem.Email,
                    Value= data.Email
                }
            }
            };

            return practitioner;
        }

        public  DiagnosticReport ConvertToFhirDiagnosticReport(ConfirmDiagnosis diagnosis)
        {
            var encounter = dbContext.Encounters.FirstOrDefault(e => e.Id == diagnosis.EncounterId);
            var patient = dbContext.Patients.FirstOrDefault(p => p.Id == diagnosis.PatientId);

            var diagnosisreport = new DiagnosticReport
            {
                Id = Convert.ToString(diagnosis.Id),
                Encounter = new ResourceReference
                {
                    Reference = $"Encounter/{diagnosis.EncounterId}",
                    Display = encounter?.Reason
                },
                Conclusion = diagnosis.Description,
                Subject= new ResourceReference
                {
                    Reference = $"Patient/{diagnosis.PatientId}",
                    Display = patient?.Name
                }
            };
            return diagnosisreport;
        }

        public Medication ConvertToFhirMedication(MedicationData meds)
        {
            var patient = dbContext.Patients.FirstOrDefaultAsync(m => m.Id == meds.PatientId);
            string dosage = meds.Dosage;
            int i = 0;
            while(i<dosage.Length && char.IsDigit(dosage[i]))
            {
                i++;
            }
            int numberPart = Convert.ToInt16(dosage.Substring(0, i));
            string unitPart = dosage.Substring(i);
            var medication = new Medication
            {
                Id = Convert.ToString(meds.Id),
                Ingredient = new List<Medication.IngredientComponent>
                {
                    new Medication.IngredientComponent
                    {
                        Strength = new Ratio
                        {
                            Numerator = new Quantity
                            {
                                Value = numberPart,
                                System = unitPart
                            }
                        }
                    }
                },

                Form = new CodeableConcept
                { 
                    Coding = new List<Coding>
                    {
                        new Coding
                        {
                            Display = meds.Type
                        }
                    }
                }
            };
            return medication;
        }
    }
}
