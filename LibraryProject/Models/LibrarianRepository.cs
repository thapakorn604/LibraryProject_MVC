using System;
using System.Collections.Generic;
using LibraryProject.Abstract;
using LibraryProject.Entities;

namespace LibraryProject.Models
{
    public class LibrarianRepository : ILibrarianRepository
    {
        private static LibrarianRepository librarianRepo
        = new LibrarianRepository();

        static List<Librarian> librarianList;
        static int counter;

        private LibrarianRepository()
        {
            librarianList = new List<Librarian>();
            counter = 1;
        }

        public bool AddLibrarian(Librarian librarian)
        {
            throw new NotImplementedException();
        }

        public bool EditLibrarian(Librarian librarian)
        {
            throw new NotImplementedException();
        }

        public int GetCounter()
        {
            throw new NotImplementedException();
        }

        public Librarian GetLibrarian(int librarianId)
        {
            throw new NotImplementedException();
        }

        public List<Librarian> GetLibrarianList()
        {
            throw new NotImplementedException();
        }

        public bool RemoveLibrarian(int librarianId)
        {
            throw new NotImplementedException();
        }

        public void SetCounter(int value)
        {
            throw new NotImplementedException();
        }

        public static LibrarianRepository getLibrarianRepository (){
            return librarianRepo;
        }
    }
}
