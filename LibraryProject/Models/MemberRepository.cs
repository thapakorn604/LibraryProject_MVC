using System;
using System.Collections.Generic;
using LibraryProject.Abstract;
using LibraryProject.Entities;

namespace LibraryProject.Models
{
    public class MemberRepository : IMemberRepository
    {
        private static MemberRepository memberRepo = new MemberRepository();

        static List<Member> memberList;
        static int counter;

        private MemberRepository()
        {
            memberList = new List<Member>();
            counter = 1;
        }

        public bool AddMember(Member member)
        {
            throw new NotImplementedException();
        }

        public bool EditMember(Member member)
        {
            throw new NotImplementedException();
        }

        public int GetCounter()
        {
            throw new NotImplementedException();
        }

        public Member GetMember(int memberId)
        {
            throw new NotImplementedException();
        }

        public List<Member> GetMemberList()
        {
            throw new NotImplementedException();
        }

        public bool RemoveMember(int memberId)
        {
            throw new NotImplementedException();
        }

        public void SetCounter(int value)
        {
            throw new NotImplementedException();
        }

        public static MemberRepository getMemberRepository(){
            return memberRepo;
        }
    }
}
