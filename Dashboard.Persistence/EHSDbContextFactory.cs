using System;
using System.Collections.Generic;
using System.Text;
using CCMS.Persistence.Infrastructure;
using Microsoft.EntityFrameworkCore;
using CCMS.Persistence.Extensions;

namespace Dashboard.Persistence
{
    public class DashboardDbContextFactory : DesignTimeDbContextFactoryBase<DashboardDbContext>
    {
        protected override DashboardDbContext CreateNewInstance(DbContextOptions<DashboardDbContext> options)
        {
            return new DashboardDbContext(options);
        }
    }
}
