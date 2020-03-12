using System;
using Dashboard.MemberManagementAPI.Enumerations;

namespace Dashboard.MemberManagementAPI.Command
{
    public class RegisterMember : CCMS.Infrastructure.MessageQueue.Models.Command
    {
        public readonly int CustomerId;
        public readonly string Salutation;
        public readonly TitleType Title;
        public readonly string FirstName;
        public readonly string MiddleName;
        public readonly string LastName;
        public readonly DateTime DoB;
        public readonly GenderType Gender;
        public readonly string Nationality;
        public readonly string Email;
        public readonly string Mobile;
        public readonly string Phone;
        public RegisterMember(Guid messageId, int customerId,string salutation, TitleType title, string firstName, string middleName, string lastName, DateTime dob,
                                GenderType gender, string email,
                                string mobile, string phone)
        {
            CustomerId = customerId;
            Salutation = salutation;
            Title = title;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            DoB = dob;
            Gender = gender;
            Email = email;
            Mobile = mobile;
            Phone = phone;
        }
    }
}
