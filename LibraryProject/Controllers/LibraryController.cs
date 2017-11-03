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
        public ActionResult BorrowBook(int memberId,int bookId){
            
            if(libRepo.BorrowBook(memberId,bookId)){
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
            return View();
        }

        [HttpPost]
        public ActionResult ReturnBook(int memberId)
        {
            return View("BorrowList",libRepo.GetBorrowList(memberId));
        }

        [HttpGet]
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
            return View("Available",libRepo.GetAvailableBook());
        }

        [HttpGet]
        public ActionResult ShowHistory()
        {
            return View("History",libRepo.GetHistoryList());
        }

        [HttpGet]
        public ActionResult SearchBook()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SearchMember()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SearchBookByName(string bookName)
        {
            List<Book> bookList = libRepo.SearchBookByName(bookName);

            if (bookList.Count()!=0)
            {
                return View("SearchBookResult", bookList);
            }
            else
            {
                ViewData["MSG"] = "with keyword : " + bookName;
                return View("SearchNotFould");
            }
        }

        [HttpPost]
        public ActionResult SearchBookById(int bookId)
        {
            List<Book> bookList = libRepo.SearchBookById(bookId);

            if (bookList.Count()!=0){
                return View("SearchBookResult", bookList); 
            }else{
                ViewData["MSG"] = "with id : " + bookId;
                return View("SearchNotFound");
            }
        }

        [HttpPost]
        public ActionResult SearchMemberByName(string memberName)
        {
            List<Member> memberList = libRepo.SearchMemberByName(memberName);

            if (memberList.Count()!=0){
                return View("SearchMemberResult", memberList); 
            }else{
                ViewData["MSG"] = "with keyword : " + memberName;
                return View("SearchNotFound");
            }
        }

        [HttpPost]
        public ActionResult SearchMemberById(int memberId)
        {
            List<Member> memberList = libRepo.SearchMemberById(memberId);

            if (memberList.Count()!=0)
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
            ViewData["MSG"] = calFee;
            return View("OverdueFee");
        }

    }
}
