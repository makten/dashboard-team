using System.Collections.Generic;
using System.Threading.Tasks;
using Dashboard.HDNManagementAPI.Model;

namespace Dashboard.MemberManagementAPI.Repository
{
    public interface IHDNRepository
    {
        Task<ICollection<HDN>> GetAllAsync();
        Task<HDN> GetByIdAsync(int id);
    }
}
