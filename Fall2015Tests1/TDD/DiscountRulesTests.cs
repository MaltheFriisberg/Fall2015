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
    public class DiscountRulesTests
    {
        
        
        [TestMethod()]
        public void CalculateDiscountTest()
        {
            
            

            Assert.Fail();
        }

        [TestMethod()]
        public void ShouldReturn0()
        {
            
            double result = DiscountRules.CalculateDiscount(300.0);
            Assert.AreEqual(0, result);
        }

        public void ShouldReturn10()
        {
            double result = DiscountRules.CalculateDiscount(700.0);
            Assert.AreEqual(10, result);
        }
    }
}