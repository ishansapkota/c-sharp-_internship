using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.Models
{
    public class ToDo
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Urgency { get; set; }
    }
}
