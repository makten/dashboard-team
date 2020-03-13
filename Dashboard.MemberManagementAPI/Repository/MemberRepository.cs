using System.Collections.Generic;
using System.Threading.Tasks;
using Dashboard.MemberManagementAPI.DataAccess;
using Dashboard.MemberManagementAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.MemberManagementAPI.Repository
{
    public class MemberRepository : IMemberRepository
    {
        private readonly MemberManagementDbContext _dbContext;
        public MemberRepository(MemberManagementDbContext dBContext)
        {
            _dbContext = dBContext;
        }
        public async Task<ICollection<Member>> GetAllAsync()
        {
            var response  = await _dbContext.Members.ToListAsync();

            return response;
        }

        public async Task<Member> GetByIdAsync(int id)
        {
            return await _dbContext.Members
                .FirstOrDefaultAsync(c => c.MemberId == id);
        }
        
    }
}
