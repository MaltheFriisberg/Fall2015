using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fall2015.Models
{
    public class Competency
    {
        public int CompetencyId { get; set; }
        public String name { get; set; }
        //Foreign Key
        public int CompetencyHeaderId { get; set; }
        //lazy loading
        public virtual CompetencyHeader CompetencyHeader { get; set; }
        
        //foreign Key #2
        public int StudentId { get; set; }
        public virtual Student student { get; set; }
    }
}
