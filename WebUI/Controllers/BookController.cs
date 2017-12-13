using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class BookController : Controller
    {
        private IBookRepository bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public ActionResult List()
        {
            return View(bookRepository.Books);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Book book)
        {
            book.BookID = NextID();
            book.Available = true;
            this.bookRepository.Add(book);
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(this.bookRepository.GetByID(id));
        }

        [HttpPost]
        public ActionResult Edit(Book book)
        {
            this.bookRepository.Replace(this.bookRepository.GetByID(book.BookID), book);
            return RedirectToAction("List");
        }

        public ActionResult Details(int id)
        {
            return View(this.bookRepository.GetByID(id));
        }

        public ActionResult Delete(int id)
        {
            this.bookRepository.Delete(this.bookRepository.GetByID(id));
            return RedirectToAction("List");
        }

        private int NextID()
        {
            return (this.bookRepository.Books.Count() + 2);
        }

    }
}