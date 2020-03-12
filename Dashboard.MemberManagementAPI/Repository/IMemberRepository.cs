using System.Collections.Generic;
using System.Threading.Tasks;
using Dashboard.MemberManagementAPI.Model;

namespace Dashboard.MemberManagementAPI.Repository
{
    public interface IMemberRepository
    {
        Task<ICollection<Member>> GetAllAsync();
        Task<Member> GetByIdAsync(int id);
    }
}
