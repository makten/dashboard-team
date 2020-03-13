using Dashboard.HDNManagementAPI.DataAccess.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.HDNManagementAPI.DataAccess
{
    public class HDNManagementDbContextFactory : DesignTimeDbContextFactoryBase<HDNManagementDbContext>
    {
        protected override HDNManagementDbContext CreateNewInstance(DbContextOptions<HDNManagementDbContext> options)
        {
            return new HDNManagementDbContext(options);
        }
    }

}
