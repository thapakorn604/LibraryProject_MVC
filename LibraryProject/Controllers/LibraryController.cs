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
    public class LibraryController : Controller
    {
        static ILibraryRepository libRepo = LibraryRepository.getLibRepository();
        
        public ActionResult Index()
        {
            return View();//Show services menu
        }

        [HttpGet]
        public ActionResult BorrowBook()
        {
            return View("BorrowBook");
        }

        [HttpPost]
        public ActionResult BorrowBook(Member member,Book book){
            
            if(libRepo.BorrowBook(member,book)){
                ViewData["MSG"] = "Borrow this book !!";
                return View("Success");
            }else{
                ViewData["MSG"] = "Borrowing that book...";
                return View("Error");
            }
        }

        [HttpGet]
        public ActionResult ReturnBook()
        {
            return View("ReturnBook");
        }

        [HttpGet]
        public ActionResult ReturnBook(int memberId)
        {
            return View(libRepo.GetBorrowList(memberId));
        }

        [HttpPut]
        public ActionResult ReturnBookProcess(int recordId)
        {
            if (libRepo.ReturnBook(recordId)){ 
                ViewData["MSG"] = "return this book !!";
                return View("Success");
            }else{ // if the book is overdue
                return RedirectToAction("OverdueFee",recordId);
            }

        }

        [HttpGet]
        public ActionResult ShowBookList()
        {
            return View("AvailableBook",libRepo.GetAvailableBook());
        }

        [HttpGet]
        public ActionResult ShowHistory()
        {
            return View("History",libRepo.GetHistoryList());
        }

        [HttpGet]
        public ActionResult searchBookByName(string bookName)
        {
            List<Book> bookList = libRepo.SearchBookByName(bookName);

            if (bookList != null)
            {
                return View("SearchBookResult", bookList);
            }
            else
            {
                ViewData["MSG"] = "with keyword : " + bookName;
                return View("SearchNotFould");
            }
        }

        [HttpGet]
        public ActionResult searchBookById(int bookId)
        {
            List<Book> bookList = libRepo.SearchBookById(bookId);

            if (bookList != null){
                return View("SearchBookResult", bookList); 
            }else{
                ViewData["MSG"] = "with id : " + bookId;
                return View("SearchNotFound");
            }
        }

        [HttpGet]
        public ActionResult searchMemberByName(string memberName)
        {
            List<Member> memberList = libRepo.SearchMemberByName(memberName);

            if (memberList != null){
                return View("SearchMemberResult", memberList); 
            }else{
                ViewData["MSG"] = "with keyword : " + memberName;
                return View("SearchNotFound");
            }
        }

        [HttpGet]
        public ActionResult searchMemberById(int memberId)
        {
            List<Member> memberList = libRepo.SearchMemberById(memberId);

            if (memberList != null)
            {
                return View("SearchMemberResult", memberList);
            }
            else
            {
                ViewData["MSG"] = "with id : " + memberId;
                return View("SearchNotFound");
            }
        }

        [HttpGet]
        public ActionResult OverdueFee(int recordId){
            double calFee = libRepo.CalOverdueFee(recordId);
            return View("OverdueFee",calFee);
        }

    }
}
