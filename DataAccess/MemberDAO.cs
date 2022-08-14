using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
namespace DataAccess
{
    public class MemberDAO
    {
        public static List<Member> GetMembers()
        {
            var listMember = new List<Member>();
            try
            {
                using (var db = new FStoreDBContext())
                {
                    listMember = db.Members.ToList();
                }
            }
            catch (Exception ex) { }
            return listMember;
        }

        public static void SaveMember(Member member)
        {
            try
            {
                using (var db = new FStoreDBContext())
                {
                    db.Members.Add(member);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateMember(Member member)
        {
            try
            {
                using (var db = new FStoreDBContext())
                {
                    db.Entry<Member>(member).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteMember(Member m)
        {
            try
            {
                using (var db = new FStoreDBContext())
                {
                    var member = db.Members.SingleOrDefault(c => c.MemberId == m.MemberId);
                    db.Members.Remove(member);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static Member GetMemberID(int Mid)
        {
            using (var db = new FStoreDBContext())
            {
                Member member = db.Members.Where(m => m.MemberId == Mid).FirstOrDefault<Member>();
                return member;
            }
        }

        public static Member GetMember(string Email, string password)
        {
            using (var db = new FStoreDBContext())
            {
                Member member = db.Members.Where(db => db.Email == Email && db.Password == password).FirstOrDefault<Member>();
                return member;
            }
        }

        public static List<Member> GetCompanyName(string CompanyName)
        {
            using (var db = new FStoreDBContext())
            {
                List<Member> company = new List<Member>();
                company = db.Members.ToList();
                return company.FindAll(Member => Member.CompanyName.Contains(CompanyName,
                    StringComparison.CurrentCultureIgnoreCase));
            }
        }

    }
}
