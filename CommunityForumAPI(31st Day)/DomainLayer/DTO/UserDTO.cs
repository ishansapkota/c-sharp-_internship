﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DomainLayer.DTO
{
    public class UserDTO
    {
        [JsonPropertyName("username")]
        public string UserName {  get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }= string.Empty;

        [JsonPropertyName("password")]
        public string Password { get; set; } = string.Empty;
    }
}
