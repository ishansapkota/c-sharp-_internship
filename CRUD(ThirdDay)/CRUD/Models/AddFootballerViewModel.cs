using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Models
{
    public class AddFootballerViewModel
    {
        [Required]
        public string Name { get; set; }

        public string Club { get; set; }

        public DateTime DoB { get; set; }
    }
}
