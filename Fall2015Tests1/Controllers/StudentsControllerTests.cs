using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fall2015.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fall2015.Models;
using Fall2015.Repositories;
using Moq;

namespace Fall2015.Controllers.Tests
{
    [TestClass()]
    public class StudentsControllerTests
    {
        [TestMethod()]
        public void StudentsControllerTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void IndexTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EditTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EditTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CreateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CreateTest1()
        {
            Mock<IStudentsRepository> mockRepo = new Mock<IStudentsRepository>();
            StudentsController controller = new StudentsController(mockRepo.Object);

            Student s = new Student {Firstname = "daniel", Lastname = "xx"};

            controller.Create(s, image: null);
            //mock is only testing if the method is called on the object
            mockRepo.Verify(a=>a.InsertOrUpdate(s));
            //possibly verify that more methods are called
            Assert.Fail();
        }

        [TestMethod()]
        public void WannaPlayDadTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void WannaPlayDad2Test()
        {
            Assert.Fail();
        }
    }
}