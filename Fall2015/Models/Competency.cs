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
        //
        public virtual CompetencyHeader CompetencyHeader { get; set; }
    }
}
