using Domain.Abstract;
using Domain.Concrete;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class RecordController : Controller
    {
        private IRecordRepository recordRepository;

        public RecordController(IRecordRepository recordRepository)
        {
            this.recordRepository = recordRepository;
        }

        [HttpGet]
        public ActionResult Borrow(int id)
        {
            ViewBag.BookID = recordRepository.GetBookByID(id).BookID;
            return View();
        }

        [HttpGet]
        public ActionResult BorrowList()
        {
            return View(recordRepository.AvailableBooks());
        }

        [HttpPost]
        public ActionResult BorrowList(string query, string criteria)
        {
            List<Book> list = new List<Book>();
            switch (criteria)
            {
                case "id":
                    foreach (var item in this.recordRepository.AvailableBooks())
                    {
                        if (item.BookID.ToString().Equals(query))
                        {
                            list.Add(item);
                        }
                    }
                    break;
                case "title":
                    foreach (var item in this.recordRepository.AvailableBooks())
                    {
                        if (item.Title.ToLower().Contains(query.ToLower()))
                        {
                            list.Add(item);
                        }
                    }
                    break;
                case "author":
                    foreach (var item in this.recordRepository.AvailableBooks())
                    {
                        if (item.Author.ToLower().Contains(query.ToLower()))
                        {
                            list.Add(item);
                        }
                    }
                    break;
                case "publisher":
                    foreach (var item in this.recordRepository.AvailableBooks())
                    {
                        if (item.Publisher.ToLower().Contains(query.ToLower()))
                        {
                            list.Add(item);
                        }
                    }
                    break;
                case "isbn":
                    foreach (var item in this.recordRepository.AvailableBooks())
                    {
                        if (item.ISBN.Equals(query))
                        {
                            list.Add(item);
                        }
                    }
                    break;
                case "all":
                    foreach (var item in this.recordRepository.AvailableBooks())
                    {
                        if (item.BookID.ToString().Equals(query))
                        {
                            list.Add(item);
                        }
                        else if (item.Title.ToLower().Contains(query.ToLower()))
                        {
                            list.Add(item);
                        }
                        else if (item.Author.ToLower().Contains(query.ToLower()))
                        {
                            list.Add(item);
                        }
                        else if (item.Publisher.ToLower().Contains(query.ToLower()))
                        {
                            list.Add(item);
                        }
                        else if (item.ISBN.ToLower().Equals(query.ToLower()))
                        {
                            list.Add(item);
                        }
                    }
                    break;
            }
            return View(list);
        }

        [HttpPost]
        public ActionResult BorrowProcess(Record record)
        {
            if (this.recordRepository.CheckValid(Convert.ToInt32(record.BookID), Convert.ToInt32(record.MemberID)) == true)
            {
                record.RecordID = NextID();
                record.BookTitle = recordRepository.GetBookByID(Convert.ToInt32(record.BookID)).Title;
                record.MemberFirstName = recordRepository.GetMemberByID(Convert.ToInt32(record.MemberID)).FirstName;
                record.MemberLastName = recordRepository.GetMemberByID(Convert.ToInt32(record.MemberID)).LastName;
                record.BorrowDate = DateTime.Today;
                record.DueDate = record.BorrowDate.AddDays(7);
                record.ReturnDate = DateTime.MinValue;
                this.recordRepository.GetBookByID(Convert.ToInt32(record.BookID)).Available = false;
                this.recordRepository.Add(record);
                return RedirectToAction("List");
            }
            else
            {
                return View("InvalidBorrow");
            }
        }

        [HttpGet]
        public ActionResult Return()
        {
            List<Record> list = new List<Record>();
            foreach (var item in this.recordRepository.Records)
            {
                if (item.Status == false)
                {
                    list.Add(item);
                }
            }
            return View(list);
        }

        [HttpPost]
        public ActionResult Return(string query)
        {
            List<Record> list = new List<Record>();
            foreach (var item in this.recordRepository.Records)
            {
                if (item.MemberID.ToString().Equals(query))
                {
                    if (item.Status == false)
                    {
                        list.Add(item);
                    }
                }
            }
            return View(list);
        }

        public ActionResult ReturnProcess(int id)
        {
            this.recordRepository.Return(this.recordRepository.GetByID(id));
            return RedirectToAction("Return");
        }

        [HttpGet]
        public ActionResult List()
        {
            return View(this.recordRepository.Records);
        }

        [HttpPost]
        public ActionResult List(string query)
        {
            List<Record> list = new List<Record>();
            foreach (var item in this.recordRepository.Records)
            {
                if (item.MemberID.ToString().Equals(query))
                {
                    list.Add(item);
                }
            }
            return View(list);
        }

        private int NextID()
        {
            return (this.recordRepository.Records.Count() + 1);
        }
    }
}