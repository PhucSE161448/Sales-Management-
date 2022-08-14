using BusinessObject.Models;
using System.Collections.Generic;

namespace DataAccess.Repository
{
    public interface IMemberRepository
    {
        List<Member> GetMembers();
        void SaveMember(Member member);
        void UpdateMember(Member member);
        void DeleteMember(Member m);
        Member GetMemberID(int Mid);
        List<Member> GetCompanyName(string CompanyName);
        Member GetMember(string Email, string password);
    }
}
