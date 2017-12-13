using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IBookRepository bookRepository;

        public HomeController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(bookRepository.Books);
        }

        [HttpPost]
        public ActionResult Index(string query = "", string criteria = "")
        {
            return View(this.bookRepository.GetSubList(query, criteria));
        }

        public ActionResult Manage()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
    }
}