using System;
using System.Collections.Generic;
using LibraryProject.Entities;
namespace LibraryProject.Abstract
{
    public interface IMemberRepository
    {
        Boolean AddMember(Member member);
        Boolean RemoveMember(int memberId);
        Boolean EditMember(Member member);
        Member GetMember(int memberId);
        List<Member> GetMemberList();
        int GetCounter();
        void SetCounter(int value);
    }
}
