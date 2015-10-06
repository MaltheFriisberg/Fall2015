using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fall2015.Models
{
    //for playing with dependency injection and mock objects
    class Emailer : IEmailer
    {
        public String sendEmail()
        {
            Console.WriteLine("Email sent");
            return "Email sent";
        }
    }
}
