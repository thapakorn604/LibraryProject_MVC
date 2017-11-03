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
        private static int counter;

        private LibrarianRepository()
        {
            librarianList = new List<Librarian> { new Librarian(0, "Mike", "mike01", "mikemike") };
            counter = 1;
        }

        public bool AddLibrarian(Librarian librarian)
        {
            if (librarian != null)
            {
                librarianList.Add(librarian);
                return true;
            }else{
                return false;
            }
        }

        public bool EditLibrarian(Librarian librarian)
        {
            if(librarian !=null){
                int index = librarianList.FindIndex(l => l.librarianId == librarian.librarianId);
                librarianList[index] = librarian;
                return true;
            }else{
                return false;
            }
        }

        public int GetCounter()
        {
            return counter;
        }

        public Librarian GetLibrarian(int librarianId)
        {
            return librarianList.Find(l => l.librarianId == librarianId);
        }

        public List<Librarian> GetLibrarianList()
        {
            return librarianList;
        }

        public bool RemoveLibrarian(int librarianId)
        {
            int index = librarianList.FindIndex(l => l.librarianId == librarianId);

            if (index >=0 && index <= librarianList.Count){
                librarianList.RemoveAt(index);
                return true;
            }else{
                return false;
            }
        }

        public void SetCounter(int value)
        {
            counter = value;
        }

        public static LibrarianRepository getLibrarianRepository (){
            return librarianRepo;
        }
    }
}
