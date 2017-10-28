using System;
using System.Collections.Generic;
using LibraryProject.Abstract;
using LibraryProject.Entities;
using LibraryProject.Models;
namespace LibraryProject.Models
{
    public class LibraryRepository : ILibraryRepository
    {
        private static LibraryRepository libRepo = new LibraryRepository();
        static BookRepository bookRepo;
        static MemberRepository memberRepo;
        static RecordRepository recordRepo;

        private LibraryRepository()
        {
            bookRepo = BookRepository.getBookRepository();
            memberRepo = MemberRepository.getMemberRepository();
            recordRepo = RecordRepository.GetRecordRepository();
        }

        public bool BorrowBook(Member member, Book book)
        {
            Member borrower = memberRepo.GetMember(member.memberId);
            Book borrowBook = bookRepo.GetBook(book.bookId);

            if (borrower != null && borrowBook != null && borrowBook.bookAmount > 0)
            {
                int recordId = recordRepo.GetCounter();
                Record newRecord = new Record(recordId, borrowBook.bookId, borrowBook.bookName, 
                                              borrower.memberId, borrower.memberName,
                                              DateTime.Now, "borrowing");
                recordRepo.SetCounter(recordId + 1);
                int index = bookRepo.GetBookList().FindIndex(b => b.bookId == borrowBook.bookId);
                bookRepo.GetBookList()[index].bookAmount -= 1;
                return true;
            }else{
                return false;
            }
        }

        public List<Record> GetHistoryList()
        {
            return recordRepo.GetRecordList();
        }

        public bool ReturnBook(int recordId)
        {
            int recordIndex = recordRepo.GetRecordList().FindIndex(r => r.recordId == recordId);
            int bookIndex = bookRepo.GetBookList().FindIndex(b => b.bookId == recordRepo.GetRecordList()[recordIndex].bookId);
            Record returnBook = recordRepo.GetRecordList()[recordIndex];

            if (returnBook.borrowDate <= DateTime.Now ){
                recordRepo.GetRecordList()[recordIndex].borrowStatus = "returned";
                bookRepo.GetBookList()[bookIndex].bookAmount += 1;
                return true;
            }else {
                return false;
            }
        }

        public List<Book> SearchBookById(int id)
        {
            return bookRepo.GetBookList().FindAll(b => b.bookId == id);
        }

        public List<Book> SearchBookByName(string bookName)
        {
            return bookRepo.GetBookList().FindAll(b => b.bookName == bookName);
        }

        public List<Member> SearchMemberById(int memberId)
        {
            return memberRepo.GetMemberList().FindAll(m => m.memberId == memberId);
        }

        public List<Member> SearchMemberByName(string memberName)
        {
            return memberRepo.GetMemberList().FindAll(m => m.memberName == memberName);
        }

        public List<Record> GetBorrowList(int memberId)
        { 
            return recordRepo.GetRecordList().FindAll(member => member.memberId == memberId && member.borrowStatus != "returned");
        }

        public static LibraryRepository getLibRepository(){
            return libRepo;
        }

        public double CalOverdueFee(int recordId)
        {
            int index = recordRepo.GetRecordList().FindIndex(r => r.recordId == recordId);
            double overdueFee = 5 * ((DateTime.Now - recordRepo.GetRecordList()[index].dueDate).TotalDays);
            return overdueFee;
        }

        public List<Book> GetAvailableBook()
        {
            return bookRepo.GetBookList().FindAll(b => b.bookAmount > 0);
        }
    }
}
