// See https://aka.ms/new-console-template for more information

using System;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using Hl7.Fhir.Serialization;

namespace fihr
{
    class Program
    {
        private const string _fhirServer = "https://server.fire.ly";

        static void Main(string[] args)
        {
            FhirClient fhirClient = new FhirClient(_fhirServer);
            Bundle patientBundle = fhirClient.Search<Patient>(new string[] {} );
        
            Console.WriteLine($"Total : {patientBundle.Total}  Entry Count: {patientBundle.Entry.Count}");
            while (patientBundle != null)
            {
                int patientNumber = 1;
                foreach (Bundle.EntryComponent patientEntry in patientBundle.Entry)
                {
                    Console.WriteLine($"{patientEntry.FullUrl}");
                    if (patientEntry.Resource != null)
                    {
                        Patient patient = (Patient)patientEntry.Resource;
                        Console.WriteLine($"{patientNumber}");
                        Console.WriteLine($"ID:{patient.Id} Name:{patient.Name[0]}");
                        patientNumber++;
                    }
                }

                patientBundle = fhirClient.Continue(patientBundle);
            }
            
            
        }
    }
}

