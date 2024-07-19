using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DomainLayer.DTO
{
    public  class PostWithUserDTO
    {
        [JsonPropertyName("posttitle")]
        public string PostTitle { get; set; } = string.Empty;

        [JsonPropertyName("postdescription")]
        public string PostDescription { get; set; } = string.Empty;

        [JsonPropertyName("firstname")]
        public string FirstName { get; set; } = string.Empty;
        
        [JsonPropertyName("lastname")]
        public string LastName { get; set; } = string.Empty;

        [JsonPropertyName("username")]
        public string UserName { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;

    }
}
