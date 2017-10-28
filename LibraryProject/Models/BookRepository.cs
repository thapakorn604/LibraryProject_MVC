using System;
using System.Collections.Generic;
using LibraryProject.Entities;
using LibraryProject.Abstract;

namespace LibraryProject.Models
                        
{
    public class BookRepository : IBookRepository
    {
        private static BookRepository bookRepo = new BookRepository();

        static List<Book> bookList;
        static int counter ;

        private BookRepository()
        {
            bookList = new List<Book>();
            counter = 1;
        }

        public bool AddBook(Book book)
        {
            bookList.Add(book);
            return true;
        }

        public bool EditBook(Book book)
        {
            throw new NotImplementedException();
        }

        public Book GetBook(int bookId)
        {
            throw new NotImplementedException();
        }

        public int GetCounter()
        {
            throw new NotImplementedException();
        }

        public bool RemoveBook(int bookId)
        {
            throw new NotImplementedException();
        }

        public void SetCounter(int value)
        {
            throw new NotImplementedException();
        }

        public static BookRepository getBookRepository ()
        {
            return bookRepo;
        }

        public List<Book> GetBookList()
        {
            throw new NotImplementedException();
        }
    }
}
