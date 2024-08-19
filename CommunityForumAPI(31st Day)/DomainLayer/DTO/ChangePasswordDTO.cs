using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DomainLayer.DTO
{
    public class ChangePasswordDTO
    {
        [JsonPropertyName("password")]
        public string? password { get; set; }
    }
}
