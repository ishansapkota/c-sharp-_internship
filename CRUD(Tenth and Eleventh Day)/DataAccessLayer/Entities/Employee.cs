using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public  class Employee
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; } = " ";

        public string Address { get; set; } = " ";

        public DateOnly DoB { get; set; }



    }
}
