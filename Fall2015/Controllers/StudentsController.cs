using Fall2015.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Fall2015.Repositories;

namespace Fall2015.Controllers
{
    public class StudentsController : Controller
    {
        public StudentsController()
        {
            
        }
        // the repository that querys the DB
        IStudentsRepository repo = new StudentsRepository();

        public ActionResult Index()
        {

            return View(repo.ToList());
        }

        [HttpGet]
        public ActionResult Edit(int studentId)
        {
            //look up a student in the repo
            Student student = repo.Find(studentId);
            ViewBag.StudentName = student.Firstname;
            
            //Open the Edit view with the chosen student object
            return View(student);
            
        }
        //this methods runs after the form is submitted in [HttpGet] Edit
        [HttpPost]
        public ActionResult Edit(Student student, HttpPostedFileBase image)
        {
            //String serverPath = Server.MapPath("~");
            //String FolderName = "/UserUploads/";
            if (image != null)
            {
                //delete the old image first?
                //student.RemoveImage(serverPath);
                student.SaveOrUpdateImage(image, Server.MapPath("~"), "/UserUploads/");

            }
            
            if (ModelState.IsValid)
            {
                repo.InsertOrUpdate(student);
                
                return RedirectToAction("Index");
            }
            return View(student);
        }
        [HttpGet]
        public ActionResult Delete(int studentId)
        {

            //look up a student in the db
            Student student = repo.Find(studentId);
            ViewBag.StudentName = student.Firstname;
            //Open the Edit view with the chosen student object
            return View(student);
        }
        [HttpPost]
        public ActionResult Delete(Student student)
        {
            //Student student = db.Students.Find(studentId);
            if (ModelState.IsValid)
            {
                repo.Delete(student.StudentId);
                return RedirectToAction("Index");
            }
            return View(student);
        }




        [HttpGet]
        public ActionResult Create()
        {
            return View();
            
            //return View(new Student());
        }

        [HttpPost]
        public ActionResult Create(Student student, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                student.SaveOrUpdateImage(image, Server.MapPath("~"), "/UserUploads/");
                repo.InsertOrUpdate(student);
                return View("Thanks");
            }
            else
            {
                return View();
            }
            
        }

    }
}
















