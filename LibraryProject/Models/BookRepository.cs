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
        private static int counter;

        private BookRepository()
        {
            bookList = new List<Book>();
            counter = 1;
        }

        public bool AddBook(Book book)
        {
            if (book != null)
            {
                bookList.Add(book);
                return true;
            }else{
                return false;
            }
        }

        public bool EditBook(Book book)
        {
            if (book != null)
            {
                int index = bookList.FindIndex(b => b.bookId == book.bookId);
                bookList[index] = book;
                return true;
            }else{
                return false;
            }
        }

        public Book GetBook(int bookId)
        {
            return bookList.Find(b => b.bookId == bookId);
        }

        public int GetCounter()
        {
            return counter;
        }

        public bool RemoveBook(int bookId)
        {
            int index = bookList.FindIndex(b => b.bookId == bookId);

            if (index >=0 && index<=bookList.Count)
            {
                bookList.RemoveAt(index);
                return true;
            }else{
                return false;
            }
        }

        public void SetCounter(int value)
        {
            counter = value;
        }

        public static BookRepository getBookRepository ()
        {
            return bookRepo;
        }

        public List<Book> GetBookList()
        {
            return bookList;
        }
    }
}
