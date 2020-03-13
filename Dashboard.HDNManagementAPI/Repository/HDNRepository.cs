using System.Collections.Generic;
using System.Threading.Tasks;
using Dashboard.HDNManagementAPI.DataAccess;
using Dashboard.HDNManagementAPI.Model;
using Dashboard.MemberManagementAPI.Repository;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.HDNManagementAPI.Repository
{
    public class HDNRepository : IHDNRepository
    {
        private readonly HDNManagementDbContext _dbContext;
        public HDNRepository(HDNManagementDbContext dBContext)
        {
            _dbContext = dBContext;
        }
        public async Task<ICollection<HDN>> GetAllAsync()
        {
            var response  = await _dbContext.Hdns
                .Include(h => h.Omgeving)
                .Include(h => h.HdnOption)
                .ToListAsync();

            return response;
        }

        public async Task<HDN> GetByIdAsync(int id)
        {
            return await _dbContext.Hdns
                .Include(h => h.Omgeving)
                .Include(h => h.HdnOption)
                .FirstOrDefaultAsync(c => c.HdnId == id);
        }
        
    }
}
