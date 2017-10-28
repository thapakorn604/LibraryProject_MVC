using System;
namespace LibraryProject.Entities
{
    public class Record
    {
        public int recordId { get; set; }
        public int bookId { get; set; }
        public string bookName { get; set; }
        public int memberId { get; set; }
        public string memberName { get; set; }
        public DateTime borrowDate { get; set; }
        public DateTime dueDate { get; set; }  //Last day of borrowing
        public DateTime returnDate { get; set; } //Actual return date
        public string borrowStatus { get; set; }

        public Record()
        {
        }

        public Record (int recordId,int bookId,string bookName,int memberId,string memberName
                       ,DateTime borrowDate,DateTime dueDate,string borrowStatus){
            this.recordId = recordId;
            this.bookId = bookId;
            this.bookName = bookName;
            this.memberId = memberId;
            this.memberName = memberName;
            this.borrowDate = borrowDate;
            this.dueDate = dueDate;
            this.returnDate = returnDate;
            this.borrowStatus = borrowStatus;
        }
}
