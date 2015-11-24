using Fall2015.Models;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Fall2015.Repositories;
using Fall2015.ViewModels;

namespace Fall2015.Controllers
{
    public class StudentsController : Controller
    {
        // the repository that querys the DB
        private readonly IStudentsRepository Studentrepo;
        private readonly IEmailer emailer;
        private StudentsRepository repo;
        private CompetencyHeaderRepo HeaderRepo;
        private CompetenciesRepository CompRepo;
        //constructor used for dependency injection
        /*public StudentsController(IStudentsRepository repo, IEmailer emailer)
        {
            this.Studentrepo = repo;
            this.emailer = emailer;
            

        }*/

        public StudentsController()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            this.repo = new StudentsRepository(context);
            this.CompRepo = new CompetenciesRepository(context);
            this.HeaderRepo = new CompetencyHeaderRepo(context);
        }
       

        public ActionResult Index()
        {
            StudentsIndexViewModel Vm = new StudentsIndexViewModel
            {
                Students = repo.All.ToList(),
                Headers = HeaderRepo.All.ToList()


            };

            //make a viewModel to hold both students and Headers/Competencies
            //return View(repo.ToList(), HeaderRepo.ToList(), CompRepo.ToList());
            //return View(repo.ToList());
            return View(Vm);
        }

        [HttpGet]
        public ActionResult Edit(int StudentId)
        {
            //look up a student in the repo
            Student student = repo.Find((int) StudentId);
            
            ViewBag.StudentName = student.Firstname;

            CreateEditStudentViewModel Vm = new CreateEditStudentViewModel
            {
                Student = student,
                Headers = HeaderRepo.All.ToList()


            };
            
            //Open the Edit view with the chosen student object
            return View(Vm);
            
        }
        //this methods runs after the form is submitted in [HttpGet] Edit
        [HttpPost]
        public ActionResult Edit(Student student, HttpPostedFileBase image, IEnumerable<int> compIds)
        {

            //String serverPath = Server.MapPath("~");
            //String FolderName = "/UserUploads/";
            
            ICollection<Competency> list = new List<Competency>();
            foreach (int i in compIds)
            {
                list.Add(CompRepo.Find(i));
            }
            
            student.Competencies = list;

            if (image != null)
            {
                //delete the old image first?
                //student.RemoveImage(serverPath);
                student.SaveOrUpdateImage(image, Server.MapPath("~"), "/UserUploads/");

            }
            
            if (ModelState.IsValid)
            {
                foreach(Competency c in list)
                {
                    //update the shared table StudentCompetencies
                    c.Students.Add(student);   
                    CompRepo.InsertOrUpdate(c);
                } 
                
                repo.InsertOrUpdate(student);
                
                return RedirectToAction("Index");
            }
            //giver null pointer fordi vm ikke er udfyldt
            return View("Index");
        }
        [HttpGet]
        public ActionResult Delete(int studentId)
        {

            //look up a student in the db
            Student student = repo.Find(studentId);
            ViewBag.StudentName = student.Firstname;
            if (ModelState.IsValid)
            {
                repo.Delete(student.StudentId);
                return RedirectToAction("Index");
            }
            //Load the index page again, can be skipped?
            return View("Index");
        }
        /*[HttpPost]
        public ActionResult Delete(Student student)
        {
            //Student student = db.Students.Find(studentId);
            if (ModelState.IsValid)
            {
                repo.Delete(student.StudentId);
                return RedirectToAction("Index");
            }
            return View(student);
        }*/




        [HttpGet]
        public ActionResult Create()
        {
            CreateEditStudentViewModel vm = new CreateEditStudentViewModel
            {
                Student = new Student(),
                Headers = HeaderRepo.ToList()
            };
            return View(vm);
            
            //return View(new Student());
        }

        [HttpPost]
        public ActionResult Create(CreateEditStudentViewModel vm, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                vm.Student.SaveOrUpdateImage(image, Server.MapPath("~"), "/UserUploads/");
                repo.InsertOrUpdate(vm.Student);
                return View("Thanks");
            }
            else
            {
                return View();
            }
            
        }

    }
}
















