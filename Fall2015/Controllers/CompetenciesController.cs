using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fall2015.Models;
using Fall2015.Repositories;

namespace Fall2015.Controllers
{
    public class CompetenciesController : Controller
    {
        private CompetenciesRepository repo = new CompetenciesRepository();
        private CompetencyHeaderRepo headerRepo = new CompetencyHeaderRepo();
        // GET: CompetenciesController1
        

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

        [HttpPost]
        public ActionResult Create(Competency competency)
        {
            repo.InsertOrUpdate(competency);
            return View("Index");
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