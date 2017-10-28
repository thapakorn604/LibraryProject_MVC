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
        private static int counter;

        private MemberRepository()
        {
            memberList = new List<Member>();
            counter = 1;
        }

        public bool AddMember(Member member)
        {
            if (member != null){
                memberList.Add(member);
                return true;
            }else{
                return false;
            }
        }

        public bool EditMember(Member member)
        {
            if (member != null){
                int index = memberList.FindIndex(m => m.memberId == member.memberId);
                memberList[index] = member;
                return true;
            }else{
                return false;
            }
        }

        public int GetCounter()
        {
            return counter;
        }

        public Member GetMember(int memberId)
        {
            return memberList.Find(m => m.memberId == memberId);
        }

        public List<Member> GetMemberList()
        {
            return memberList;
        }

        public bool RemoveMember(int memberId)
        {
            int index = memberList.FindIndex(m => m.memberId == memberId);

            if (index >=0 && index >= memberList.Count){
                memberList.RemoveAt(index);
                return true;
            }else{
                return false;
            }
        }

        public void SetCounter(int value)
        {
            counter = value;
        }

        public static MemberRepository getMemberRepository(){
            return memberRepo;
        }
    }
}
