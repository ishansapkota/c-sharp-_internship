using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntitiesOrModel
{
    public class Work
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Day { get; set; }

        [MaxLength(1000)]
        public string WorksDone { get; set; } = " ";

        [MaxLength(255)]
        public string ThingsLearnt { get; set; } = " ";

        public string GitHubLink { get; set; } = " ";
    }
}
