using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DomainLayer.DTO
{
    public class PostDTO
    {
        [JsonPropertyName("posttitle")]
        public string PostTitle { get; set; } = string.Empty;

        [JsonPropertyName("postdescription")]
        public string PostDescription { get; set; } = string.Empty;

    }
}
