using System;
using Dashboard.MemberManagementAPI.Model;
using Microsoft.EntityFrameworkCore;
using Polly;

namespace Dashboard.MemberManagementAPI.DataAccess
{
    public class MemberManagementDbContext : DbContext
    {
        public MemberManagementDbContext(DbContextOptions<MemberManagementDbContext> options) : base(options)
        {
        }

        public DbSet<Member> Members { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Member>().HasKey(p => p.MemberId);
            builder.Entity<Member>().ToTable("Member");

            base.OnModelCreating(builder);
        }

        public void MigrateDB()
        {
            Policy
                .Handle<Exception>()
                .WaitAndRetry(10, r => TimeSpan.FromSeconds(10))
                .Execute(() => Database.Migrate());
        }
    }
}
