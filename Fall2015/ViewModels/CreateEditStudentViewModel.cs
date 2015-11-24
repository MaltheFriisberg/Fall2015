using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fall2015.Models;

namespace Fall2015.ViewModels
{
    public class CreateEditStudentViewModel
    {
        //viewModels cannot save to the DB. It is used to collect data for our razor views.
        //AutoMapper will map the properties from the modelclass if they are named the same
        public Student Student { get; set; }
        public List<CompetencyHeader> Headers { get; set; } 
    }
}
