using BusinessObject.Models;
using System.Collections.Generic;

namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public void DeleteMember(Member m)
        => MemberDAO.DeleteMember(m);

        public List<Member> GetCompanyName(string CompanyName)
        => MemberDAO.GetCompanyName(CompanyName);

        public Member GetMember(string Email, string password)
        => MemberDAO.GetMember(Email, password);

        public Member GetMemberID(int Mid)
        => MemberDAO.GetMemberID(Mid);

        public List<Member> GetMembers()
        => MemberDAO.GetMembers();


        public void SaveMember(Member member)
        => MemberDAO.SaveMember(member);

        public void UpdateMember(Member member)
        => MemberDAO.UpdateMember(member);


    }
}
