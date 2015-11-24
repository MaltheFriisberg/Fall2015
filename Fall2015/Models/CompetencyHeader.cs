using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fall2015.Models
{
    public class CompetencyHeader

    {
        public int CompetencyHeaderId { get; set; }
        public string Name { get; set; }
        // the header will have multiple competencies oneToMany
        public virtual ICollection<Competency> Competencies { get; set; } 
    }
}
