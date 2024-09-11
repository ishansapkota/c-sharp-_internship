using Hl7.Fhir.Model;

namespace SHG.DTO
{
    public class PractitionerDTO
    {
        public bool Active { get; set; }
        public List<NameDTO> Name { get; set; }
        public List<ContactDTO> Telecom { get; set; }
    }

    public class NameDTO
    {
        public UseDTO Use { get; set; }
        public ValueDTO Family { get; set; }
        public List<ValueDTO> Given { get; set; }
    }

    public class UseDTO
    {
        public string Value { get; set; }
    }

    public class ValueDTO
    {
        public string Value { get; set; }
    }

    public class ContactDTO
    {
        public string System { get; set; }
        public string Value { get; set; }
    }


}
