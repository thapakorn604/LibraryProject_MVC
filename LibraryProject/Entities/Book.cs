using System;
namespace LibraryProject.Entities
{
    public class Book
    {
        public int bookId { get; set; }
        public string bookName { get; set; }
        public string bookAuthor { get; set; }
        public string category { get; set; }
        public int bookPages { get; set; }
        public int bookAmount { get; set; }

        public Book()
        {
        }

        public Book(int bookId,string bookName,string bookAuthor,
                    string category,int bookPages,int bookAmount){
            this.bookId = bookId;
            this.bookName = bookName;
            this.bookAuthor = bookAuthor;
            this.category = category;
            this.bookPages = bookPages;
            this.bookAmount = bookAmount;
        }
    }
}
