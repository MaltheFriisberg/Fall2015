using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fall2015.TDD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fall2015.TDD.Tests
{
    
    [TestClass()]
    public class OurTimeSpanTests
    {
        OurTimeSpan OurTime = new OurTimeSpan
        {
            //kl 13.30
            FromTime = new DateTime(2015, 2, 1, 13, 30, 0),
            //kl 14.00
            ToTime = new DateTime(2015, 2, 1, 14, 0, 0)
        };
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Not a valid timespan")]
        public void TriggerException()
        {
            OurTimeSpan span = new OurTimeSpan
            {
                
                FromTime = new DateTime(2015, 2, 1, 14, 30, 0),
                
                ToTime = new DateTime(2015, 2, 1, 13, 0, 0)


            };
            OurTime.OverLap(span);
        }

        [TestMethod()]
        public void OverLapTest()
        {
            Assert.Fail();
        }
        [TestMethod()]
        public void IsOverlapping()
        {
             OurTimeSpan span = new OurTimeSpan
             {
                //April
                FromTime = new DateTime(2015, 2, 1, 13, 15, 0),
                //Februar
                ToTime = new DateTime(2015, 2, 1, 13, 45, 0)
            };
            Assert.IsFalse(OurTime.OverLap(span));
        }
        [TestMethod()]
        public void NotOverlapping()
        {
            OurTimeSpan span = new OurTimeSpan
            {
                FromTime = new DateTime(2015, 2, 1, 14, 30,0),
                ToTime = new DateTime(2015, 2, 1, 1, 15, 0)
            };
            Assert.IsTrue(OurTime.OverLap(span));
        }

        

    }
}