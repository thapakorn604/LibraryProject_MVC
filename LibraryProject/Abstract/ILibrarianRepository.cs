using System;
using System.Collections.Generic;
using LibraryProject.Entities;
namespace LibraryProject.Abstract
{
    public interface ILibrarianRepository
    {
        Boolean AddLibrarian(Librarian librarian);
        Boolean RemoveLibrarian(int librarianId);
        Boolean EditLibrarian(Librarian librarian);
        Librarian GetLibrarian(int librarianId);
        List<Librarian> GetLibrarianList();
        int GetCounter();
        void SetCounter(int value);
    }
}
