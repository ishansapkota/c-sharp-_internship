using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entity
{
    public class AuthUser
    {
        [Key]
        public int Id { get; set; }

        public string UserName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public byte[] PasswordSalt { get; set; } = Array.Empty<byte>();

        public byte[] PasswordHash { get; set; } = Array.Empty<byte>();

        public string Roles { get; set; } = string.Empty;

    }
}
