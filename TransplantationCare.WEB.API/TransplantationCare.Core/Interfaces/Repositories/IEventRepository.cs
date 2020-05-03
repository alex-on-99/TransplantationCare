using System.Collections.Generic;
using System.Threading.Tasks;
using TransplantationCare.Core.Models.DataBase;

namespace TransplantationCare.Core.Interfaces.Repositories
{
    public interface IEventRepository : IRepository<Event>
    {
        Task<Event> GetWithIncludesByIdAsync(int id);

        Task<List<Event>> GetAllWithIncludesByUserIdAsync(int userId);

        Task<List<Event>> GetAllWithIncludesByAdminIdAsync(int adminId);
    }
}
