using System;
using System.Linq;
using System.Text;
using Dashboard.MemberManagementAPI.Model;

namespace Dashboard.MemberManagementAPI.DataAccess
{
    /// <summary>
    /// This class is used for seeding database for the Dashboard application
    /// </summary>
    public class MemberManagementApiInitializer
    {
        public static void Initialize(MemberManagementDbContext context)
        {
            var initializer = new MemberManagementApiInitializer();
            initializer.SeedEverything(context);
        }

        private void SeedEverything(MemberManagementDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Customers.Any())
            {
                return; // we are seeded
            }

            SeedCustomers(context);
        }

        private void SeedCustomers(MemberManagementDbContext context)
        {
            var customers = new[]
            {
                new Member
                {
                    FirstName = "Hafiz", 
                    LastName = "Abass",
                    MiddleName = "Gbulo",
                    DoB = new DateTime(1974, 02, 01), 
                    Email = GenerateRandomEmail() + "@gmail.com", 
                    Phone = "024443323121",
                   
                },new Member
                {
                    FirstName = "Joris", 
                    LastName = "Hein",
                    MiddleName = "Van",
                    DoB = new DateTime(1974, 02, 01), 
                    Email = GenerateRandomEmail() + "@gmail.com", 
                    Phone = "024443323121",
                   
                },new Member
                {
                    FirstName = "Raimund", 
                    LastName = "Drucker",
                    DoB = new DateTime(1974, 02, 01), 
                    Email = GenerateRandomEmail() + "@gmail.com", 
                    Phone = "024443323121",
                   
                },new Member
                {
                    FirstName = "Hafiz", 
                    LastName = "Abass",
                    MiddleName = "Gbulo",
                    DoB = new DateTime(1974, 02, 01), 
                    Email = GenerateRandomEmail() + "@gmail.com", 
                    Phone = "024443323121",
                   
                },
               

            };

            context.Customers.AddRange(customers);
            context.SaveChanges();
        }

        protected string GenerateRandomEmail()
        {
            string SALTCHARS = "abcdefghijklmnopqrstuvwxyz1234567890";
            StringBuilder salt = new StringBuilder();
            Random rnd = new Random();

            while (salt.Length < 10)
            { 
                int index = (int)(rnd.NextDouble() * SALTCHARS.Length);
                salt.Append(SALTCHARS.ElementAtOrDefault(index));
            }

            string saltStr = salt.ToString();
            return saltStr;
        }
    }
}
