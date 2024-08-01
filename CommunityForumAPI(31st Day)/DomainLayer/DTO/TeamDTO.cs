using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DomainLayer.DTO
{
    public class TeamDTO
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("teamname")]
        public string TeamName { get; set; }
        [JsonPropertyName("points")]
        public int Points { get; set; }
    }
}
