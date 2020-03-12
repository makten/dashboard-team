using Dashboard.Persistence.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.MemberManagementAPI.DataAccess
{
    public class MemberManagementDbContextFactory : DesignTimeDbContextFactoryBase<MemberManagementDbContext>
    {
        protected override MemberManagementDbContext CreateNewInstance(DbContextOptions<MemberManagementDbContext> options)
        {
            return new MemberManagementDbContext(options);
        }
    }

}
