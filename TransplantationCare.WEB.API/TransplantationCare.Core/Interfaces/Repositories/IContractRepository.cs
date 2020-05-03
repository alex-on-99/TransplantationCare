using System.Collections.Generic;
using System.Threading.Tasks;
using TransplantationCare.Core.Models.DataBase;

namespace TransplantationCare.Core.Interfaces.Repositories
{
    public interface IContractRepository : IRepository<Contract>
    {
        Task<List<Contract>> GetAllWithIncludesAsync();

        Task<Contract> GetWithIncludesByIdAsync(int id);
    }
}
