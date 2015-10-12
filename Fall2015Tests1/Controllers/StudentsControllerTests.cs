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
            Mock<IStudentsRepository> repoMock = new Mock<IStudentsRepository>();
            Mock<IEmailer> emailMock = new Mock<IEmailer>();
            StudentsController controller = new StudentsController(repoMock.Object, emailMock.Object);
            Student x = new Student {StudentId = 2};
            controller.Edit(x.StudentId);

            repoMock.Verify(a => a.InsertOrUpdate(x));

            //Assert.Fail();
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
            Mock<IEmailer> emailMock = new Mock<IEmailer>();
            StudentsController controller = new StudentsController(mockRepo.Object, emailMock.Object);
            Mock<IStudent> studentMock = new Mock<IStudent>();
            Student s = new Student
            {
                Firstname = "daniel",
                Lastname = "xx",
                ImageFilePath = "xy",
                Email = "hej@sol.dk",
                MobilePhone = "23232323",
                StudentId = 2
            };

            controller.Create(s, null);
            //studentMock.Verify(a => a.SaveOrUpdateImage());
           //ock
            //mock is only testing if the method is called on the object
            mockRepo.Verify(a=>a.InsertOrUpdate(s));
            //possibly verify that more methods are called
            mockRepo.Verify(a => a.Save());
            //Assert.Fail();
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