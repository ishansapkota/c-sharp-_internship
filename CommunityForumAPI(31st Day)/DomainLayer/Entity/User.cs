using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entity
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        
        public string FirstName { get; set; } = string.Empty;   

        public string LastName { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;
        
        public DateTime DoB { get; set; }

        [ForeignKey("AuthUserId")]
        public AuthUser AuthUsers { get; set; }

        public int AuthUserId { get; set; }
    }
}
