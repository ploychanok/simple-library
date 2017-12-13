using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class LibrarianController : Controller
    {
        private ILibrarianRepository librarianRepository;

        public LibrarianController(ILibrarianRepository librarianRepository)
        {
            this.librarianRepository = librarianRepository;
        }

        public ActionResult Index(int id)
        {
            ViewBag.UserName = this.librarianRepository.GetByID(id).Username;
            ViewBag.Id = this.librarianRepository.GetByID(id).LibrarianID;
            return View();
        }

        public ActionResult List()
        {
            return View(this.librarianRepository.Librarians);
        }

        public ActionResult Details(int id)
        {
            return View(this.librarianRepository.GetByID(id));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(this.librarianRepository.GetByID(id));
        }

        [HttpPost]
        public ActionResult Edit(Librarian librarian)
        {
            this.librarianRepository.Replace(this.librarianRepository.GetByID(librarian.LibrarianID), librarian);
            return RedirectToAction("List");
        }

        public ActionResult Delete(int id)
        {
            this.librarianRepository.Delete(this.librarianRepository.GetByID(id));
            return RedirectToAction("List");
        }
    }
}