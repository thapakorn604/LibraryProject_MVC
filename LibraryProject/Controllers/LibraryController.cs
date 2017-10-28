using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryProject.Controllers
{
    public class LibraryController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BorrowBook()
        {
            return View();
        }

        public ActionResult ReturnBook()
        {
            return View();
        }

        public ActionResult CheckReturnDate()
        {
            return View();
        }

        public ActionResult ShowBookList()
        {
            return View();
        }

        public ActionResult ShowHistory()
        {
            return View();
        }

        public ActionResult searchBookByName()
        {
            return View();
        }

        public ActionResult searchBookById()
        {
            return View();
        }

        public ActionResult searchMemberByName()
        {
            return View();
        }

        public ActionResult searchMemberById()
        {
            return View();
        }

        public ActionResult CheckOverdueFee() 
        {
            return View();
        }

    }
}
