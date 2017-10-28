using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryProject.Models;
using LibraryProject.Abstract;
using LibraryProject.Entities;
using System.Web.Mvc;
using System.Net;

namespace LibraryProject.Controllers
{
    public class MemberController : Controller
    {
        static IMemberRepository memberRepo = MemberRepository.getMemberRepository();

        public MemberController(){}

        [HttpGet]
        public ActionResult Index()
        {
            return View (memberRepo.GetMemberList());
        }

        [HttpGet]
        public ActionResult AddMember()
        {
            return View("Add");
        }

        [HttpPost]
        public ActionResult AddMember(string memberName,string username,string password)
        {
            int memberId = memberRepo.GetCounter();
            Member newMember = new Member(memberId, memberName, username, password);
            if (memberRepo.AddMember(newMember))
            {
                memberRepo.SetCounter(memberRepo.GetCounter() + 1);
                ViewData["MSG"] = "Add a member!!";
                return View("Success");
            }
            else
            {
                ViewData["MSG"] = "adding member...";
                return View("Errror");
            }
        }

        [HttpDelete]
        public ActionResult RemoveMember(int memberId)
        {
            if (memberRepo.RemoveMember(memberId))
            {
                ViewData["MSG"] = "Remove slected member !!!";
                return View("Success");
            }
            else
            {
                ViewData["MSG"] = "Removing member...";
                return View("Error");
            }
        }

        [HttpGet]
        public ActionResult EditMember(int memberId)
        {
            {
                Member currentMember = memberRepo.GetMember(memberId);
                if (currentMember == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View("Edit", currentMember);
                }
            }

        }

        [HttpPut]
        public ActionResult EditMember(int memberId,string memberName,string username,string password)//id cannot edit
        {
            Member updatedMember = new Member(memberId, memberName, username, password);

            if (memberRepo.EditMember(updatedMember))
            {
                ViewData["MSG"] = "Updated member!!!";
                return View("Success");
            }
            else
            {
                ViewData["MSG"] = "Updating member...";
                return View("Errror");
            }

        }

        [HttpGet]
        public ActionResult ShowMemberInfo(int memberId)
        {
            Member currentMember = memberRepo.GetMember(memberId);

            if (currentMember == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View("Info", currentMember);
            }
        }
    }
}
