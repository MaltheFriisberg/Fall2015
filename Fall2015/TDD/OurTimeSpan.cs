using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fall2015.Models;

namespace Fall2015.TDD
{
    public class OurTimeSpan
    {
        public DateTime FromTime { get; set; }
        public DateTime ToTime { get; set; }

        public Boolean OverLap(OurTimeSpan span)
        {
            if (span.FromTime > span.ToTime)
            {
                throw new ArgumentException("Not a valid timespan");
            }


            return FromTime >= span.FromTime && FromTime < span.ToTime
                   || ToTime <= span.ToTime && ToTime > span.FromTime
                   || FromTime < span.FromTime && ToTime > span.ToTime;
        }
    }
}
