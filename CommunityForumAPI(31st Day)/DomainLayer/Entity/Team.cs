using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entity
{
    public class Team
    {
        public int Id { get; set; }
        public string TeamName { get; set; } = string.Empty;
        public int Points { get; set; }
        public int GoalDifference { get; set; }

    }
}
