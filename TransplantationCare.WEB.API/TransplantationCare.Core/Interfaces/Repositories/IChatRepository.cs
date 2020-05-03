using System.Collections.Generic;
using System.Threading.Tasks;
using TransplantationCare.Core.Models.DataBase;

namespace TransplantationCare.Core.Interfaces.Repositories
{
    public interface IChatRepository : IRepository<Chat>
    {
        Task<List<Chat>> GetAllWithIncludesByContractIdAsync(int contractId);
    }
}
