using System.Collections.Generic;
using System.Threading.Tasks;
using TransplantationCare.Core.Models.DataBase;

namespace TransplantationCare.Core.Interfaces.Repositories
{
    public interface IUserContractRepository : IRepository<UserContract>
    {
        Task<List<UserContract>> GetAllWithIncludesAsync();

        Task<UserContract> GetWithIncludesByIdAsync(int id);

        Task<List<UserContract>> GetAllWithIncludesByUserIdAsync(int userId);

        Task<List<UserContract>> GetAllWithIncludesByContractIdAsync(int contractId);
    }
}
