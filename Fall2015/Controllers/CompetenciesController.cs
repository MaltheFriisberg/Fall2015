using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Fall2015.Models;
using Fall2015.Repositories;

namespace Fall2015.Controllers
{
    public class CompetenciesController : Controller
    {
        private CompetenciesRepository repo;
        private CompetencyHeaderRepo headerRepo;
        // GET: CompetenciesController1

        public CompetenciesController()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            this.repo = new CompetenciesRepository(context);
            this.headerRepo = new CompetencyHeaderRepo(context);

        }


        [HttpGet]
        public ActionResult Index()
        {
            return View(repo.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.CompetencyHeaderId = new SelectList(headerRepo.All, "CompetencyHeaderId", "Name");
            //TempData.
            return View();
        }

        [HttpGet]
        public ViewResult SqlTool()
        {
            return View("SqlTool");
        }

        [HttpPost]
        public JsonResult SqlTool(string query)
        {
            var type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == query);
            ApplicationDbContext context = new ApplicationDbContext();
            DbSet contextDbSet;
            
            
            contextDbSet = context.Set(type);
                
            
            return Json(contextDbSet.ToString());
        }

        [HttpPost]
        public JsonResult Create(string name, string competencyHeaderName)
        {
            //https://msdn.microsoft.com/en-us/data/jj573936.aspx
            var competencyHeaders = headerRepo.All;
            int count = competencyHeaders.Count();
            CompetencyHeader header = competencyHeaders.First(x => x.Name == competencyHeaderName);
            //var result = competencyHeaders.Where(x => x.Name.Equals(name)).First();
            
                //headerRepo.Find(result.CompetencyHeaderId);
                var competency = new Competency
                {
                    Name = name, CompetencyHeader = header, CompetencyHeaderId = header.CompetencyHeaderId
                };
            repo.InsertOrUpdate(competency);

            return Json(competency.Name);
        }
        [HttpGet]
        public ActionResult Edit()
        {
            ViewBag.CompetencyHeaderId = new SelectList(headerRepo.All, "CompetencyHeaderId", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Edit(Competency competency)
        {
            repo.InsertOrUpdate(competency);
            return View("Index", repo.ToList());
        }

        public ActionResult Details()
        {
            return View();
        }
        /*[HttpGet]
        public ActionResult Delete()
        {
            return View();
        } */

        //[HttpGet]
        public ActionResult Delete(int id)
        {
            repo.Delete(id);
            Competency competency = repo.Find(id);  
            return View("Index", repo.ToList());
        }
    }
}