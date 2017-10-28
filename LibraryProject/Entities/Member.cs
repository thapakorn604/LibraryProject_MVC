using System;
namespace LibraryProject.Entities
{
    public class Member
    {
        public int memberId { get; set; }
        public string memberName { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public Member()
        {
        }

        public Member(int memberId,string memberName,string username,string password)
        {
            this.memberId = memberId;
            this.memberName = memberName;
            this.username = username;
            this.password = password;
        }
    }
}
