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
    public class LibrarianController : Controller
    {
        static ILibrarianRepository librarianRepo = LibrarianRepository.getLibrarianRepository();

        public LibrarianController(){}

        [HttpGet]
        public ActionResult Index() //Show all librarian with action links related to CRUD
        {
            return View (librarianRepo.GetLibrarianList());
        }

        [HttpGet]
        public ActionResult AddLibrarian()
        {
            return View("Add");
        }

        [HttpPost]
        public ActionResult AddBook(string librarianName,string username,string password)
        {
            int librarianId = librarianRepo.GetCounter();
            Librarian newLibrarian = new Librarian(librarianId, librarianName, username, password);

            if (librarianRepo.AddLibrarian(newLibrarian))
            {
                ViewData["MSG"] = "Add a librarian!!";
                return View("Success");
            }
            else
            {
                ViewData["MSG"] = "adding librarian...";
                return View("Errror");
            }
        }

        [HttpDelete]
        public ActionResult RemoveLibrarian(int librarianId)
        {
            if (librarianRepo.RemoveLibrarian(librarianId))
            {
                ViewData["MSG"] = "Remove slected librarian!!";
                return View("Success");
            }
            else
            {
                ViewData["MSG"] = "Removing librarian..";
                return View("Error");
            }
        }

        [HttpGet]
        public ActionResult EditLibrarian(int librarianId)
        {
            {
                Librarian currentLibrarian = librarianRepo.GetLibrarian(librarianId);
                if (currentLibrarian == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View("Edit", currentLibrarian);
                }
            }

        }

        [HttpPut]
        public ActionResult EditLibrarian(int librarianId,string librarianName, string username, string password)//Id cannot edit
        {
            Librarian updatedLibrarian = new Librarian(librarianId, librarianName, username, password);

            if (librarianRepo.EditLibrarian(updatedLibrarian))
            {
                ViewData["MSG"] = "Updated librarian!!";
                return View("Success");
            }
            else
            {
                ViewData["MSG"] = "Updating book..";
                return View("Errror");
            }

        }

        [HttpGet]
        public ActionResult ShowLibrarianInfo(int librarianId)
        {
            Librarian currentLibrarian = librarianRepo.GetLibrarian(librarianId);

            if (currentLibrarian == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View("Info", currentLibrarian);
            }
        }
    }
}
