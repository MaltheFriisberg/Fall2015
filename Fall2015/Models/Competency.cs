using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fall2015.Models
{
    public class Competency
    {
        public int CompetencyId { get; set; }
        public string Name { get; set; }
        //Foreign Key
        public int CompetencyHeaderId { get; set; }
        //
        
        public virtual CompetencyHeader CompetencyHeader { get; set; }
        //for the joined table  
        public virtual ICollection<Student> Students { get; set; } 
    }
}
