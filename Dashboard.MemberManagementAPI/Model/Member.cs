using System;

namespace Dashboard.MemberManagementAPI.Model
{
    public class Member
    {
        public int MemberId { get; set; }
        public string Salutation { get; set; }
        public string  FirstName { get; set; }
        public string  MiddleName { get; set; }
        public string  LastName { get; set; }
        public DateTime DoB { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
    }
}
