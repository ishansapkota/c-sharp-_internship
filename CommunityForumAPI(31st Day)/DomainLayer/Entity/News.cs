using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entity
{
    public class News
    {
        [Key]
        public int Id { get; set; }

        public string NewsTitle { get; set; } = string.Empty;

        public string NewsDescription { get; set; } = string.Empty;

    }
}
