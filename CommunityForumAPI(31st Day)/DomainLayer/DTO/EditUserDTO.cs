using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DomainLayer.DTO
{
    public class EditUserDTO
    {
        [JsonPropertyName("firstname")]
        public string FirstName { get; set; } = string.Empty;
        [JsonPropertyName("lastname")]
        public string LastName { get; set; } = string.Empty;
        [JsonPropertyName("address")]
        public string Address { get; set; } = string.Empty;
        [JsonPropertyName("dob")]
        public string DoB { get; set; }
    }
}
