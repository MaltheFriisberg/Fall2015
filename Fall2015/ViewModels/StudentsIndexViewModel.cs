using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fall2015.Models;

namespace Fall2015.ViewModels
{
    public class StudentsIndexViewModel
    {
        public IEnumerable<Student> Students { get; set; }
        public IEnumerable<CompetencyHeader> Headers { get; set; }              
    }
}
