using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entity
{
    public class AuthUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Email { get; set; } = string.Empty;

        public byte[] PasswordSalt { get; set; } = Array.Empty<byte>();

        public byte[] PasswordHash { get; set;} = Array.Empty<byte>();

        public string Roles { get; set; } = string.Empty;

    }
}
