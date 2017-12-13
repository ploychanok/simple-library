using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class MemberController : Controller
    {
        private IMemberRepository memberRepository;

        public MemberController(IMemberRepository memberRepository)
        {
            this.memberRepository = memberRepository;
        }

        public ActionResult Index(int id)
        {
            return View();
        }

        public ActionResult List()
        {
            return View(this.memberRepository.Members);
        }

        public ActionResult Details(int id)
        {
            return View(this.memberRepository.GetByID(id));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(this.memberRepository.GetByID(id));
        }

        [HttpPost]
        public ActionResult Edit(Member member)
        {
            this.memberRepository.Replace(this.memberRepository.GetByID(member.MemberID), member);
            return RedirectToAction("List");
        }

        public ActionResult Delete(int id)
        {
            this.memberRepository.Delete(this.memberRepository.GetByID(id));
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Member member)
        {
            member.MemberID = NextID();
            this.memberRepository.Add(member);
            return RedirectToAction("List");
        }

        private int NextID()
        {
            return (this.memberRepository.Members.Count() + 1);
        }
    }
}