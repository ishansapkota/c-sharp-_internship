using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntitiesOrModel
{
    public class Journal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int JournalID { get; set; }


        public string ExperienceTitle { get; set; } = " ";

        public string ExperienceDescription { get; set; } = "";


    }
}
