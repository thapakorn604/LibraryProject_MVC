using System;
using System.Collections.Generic;
using LibraryProject.Entities;
namespace LibraryProject.Abstract
{
    public interface ILibraryRepository
    {
        Boolean BorrowBook(Member member, Book book);
        Boolean ReturnBook(int recordId);
        List<Record> GetHistoryList();
        List<Record> GetBorrowList(int memberId);
        List<Book> GetAvailableBook();
        List<Book> SearchBookByName(string bookName);
        List<Book> SearchBookById(int id);
        List<Member> SearchMemberByName(string memberName);
        List<Member> SearchMemberById(int memberId);
        double CalOverdueFee(int recordId);
    }
}