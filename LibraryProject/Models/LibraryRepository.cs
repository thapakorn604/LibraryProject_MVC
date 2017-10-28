using System;
using LibraryProject.Abstract;
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
    }
}
