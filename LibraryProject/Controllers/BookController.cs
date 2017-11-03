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
    public class BookController : Controller
    {
        static IBookRepository bookRepo = BookRepository.getBookRepository();
                                                        
        public BookController(){
            
        }

        [HttpGet]
        public ActionResult Index() //Show all books with ActionLinks
        {
            return View (bookRepo.GetBookList());
        }

        [HttpGet]
        public ActionResult AddBook(){
            return View("Add");
        }

        [HttpPost]
        public ActionResult AddBook(string bookName, string bookAuthor,
                                      string category, int bookPages, int bookAmount)
        {
            int bookId = bookRepo.GetCounter();
            Book newBook = new Book(bookId,bookName, bookAuthor, category, bookPages, bookAmount);
            if (bookRepo.AddBook(newBook))
            {
                bookRepo.SetCounter(bookRepo.GetCounter()+1);
                ViewData["MSG"] = "Add a book!!";
                return View("Success");
            }
            else
            {
                ViewData["MSG"] = "adding book...";
                return View("Errror");
            }
        }

        [HttpGet]
        public ActionResult RemoveBook(int bookId)
        {
            if (bookRepo.RemoveBook(bookId))
            {
                ViewData["MSG"] = "Remove slected book !!";
                return View("Success");
            }else{
                ViewData["MSG"] = "Removing book..";
                return View("Error");
            }
        }

        [HttpGet]
        public ActionResult EditBook(int bookId){
            {
                Book currentBook = bookRepo.GetBook(bookId);
                if (currentBook == null)
                {
                    return HttpNotFound();
                }else{
                    return View("Edit",currentBook);
                }
            }
          
        }

        [HttpPost]
        public ActionResult EditBook (int bookId,string bookName,string bookAuthor,//bookId cannot edit
                                      string category,int bookPages,int bookAmount){
            Book updatedBook = new Book(bookId,bookName,bookAuthor,category,bookPages,bookAmount);

            if(bookRepo.EditBook(updatedBook)){
                ViewData["MSG"] = "Updated book!!";
                return View("Success");
            }else{
                ViewData["MSG"] = "Updating book..";
                return View("Errror"); 
            }

        }

        [HttpGet]
        public ActionResult ShowBookInfo(int bookId)
        {
            Book currentBook = bookRepo.GetBook(bookId);

            if (currentBook == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View("Info", currentBook);
            }
        }
    }
}
