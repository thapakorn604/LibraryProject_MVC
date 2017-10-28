using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View ();
        }

        public ActionResult RedirectToLibrary()
        {
            return RedirectToAction("Index", "Library");
        }

        public ActionResult RedirectToBook ()
        {
            return RedirectToAction("Index", "Book");
        }

        public ActionResult RedirectToLibrarian()
        {
            return RedirectToAction("Index", "Librarian");
        }

        public ActionResult RedirectToMember ()
        {
            return RedirectToAction("Index", "Member");
        }
    }
}
