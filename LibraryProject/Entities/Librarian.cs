using System;
namespace LibraryProject.Entities
{
    public class Librarian
    {
        public int librarianId { get; set; }
        public string librarianName { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public Librarian()
        {
        }

        public Librarian(int librarianId,string librarianName,string username,string password)
        {
            this.librarianId = librarianId;
            this.librarianName = librarianName;
            this.username = username;
            this.password = password;
        }
    }
}
