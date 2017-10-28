using System;
using System.Collections.Generic;
using LibraryProject.Entities;
namespace LibraryProject.Abstract
{
    public interface IBookRepository
    {
        Boolean AddBook(Book book);
        Boolean RemoveBook(int bookId);
        Boolean EditBook(Book book);
        Book GetBook(int bookId);
        List<Book> GetBookList();
        int GetCounter();
        void SetCounter(int value);

    }
}
