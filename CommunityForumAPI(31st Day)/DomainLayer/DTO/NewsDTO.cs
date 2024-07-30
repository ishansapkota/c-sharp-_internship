using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DomainLayer.DTO
{
    public class NewsDTO
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("newstitle")]
        public string NewsTitle { get; set; }

        [JsonPropertyName("newsdescription")]
        public string NewsDescription { get; set; }
    }
}
