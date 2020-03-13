using System;
using Dashboard.HDNManagementAPI.Model;
using Microsoft.EntityFrameworkCore;
using Polly;

namespace Dashboard.HDNManagementAPI.DataAccess
{
    public class HDNManagementDbContext : DbContext
    {
        public HDNManagementDbContext(DbContextOptions<HDNManagementDbContext> options) : base(options)
        {
        }

        public DbSet<HDN> Hdns { get; set; }
        public DbSet<Omgeving> Omgevings { get; set; }
        public DbSet<HdnOption> HdnOptions { get; set; }
        public DbSet<Label> Labels { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<HDN>().HasKey(p => p.HdnId);
            builder.Entity<HDN>().ToTable("Hdn");
            
            builder.Entity<Omgeving>().HasKey(p => p.OmgevingId);
            builder.Entity<Omgeving>().ToTable("Omgeving");

            builder.Entity<HdnOption>().HasKey(p => p.HdnOptionId);
            builder.Entity<HdnOption>().ToTable("HdnOption");

            builder.Entity<Label>().HasKey(p => p.LabelId);
            builder.Entity<Label>().ToTable("Label");

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
