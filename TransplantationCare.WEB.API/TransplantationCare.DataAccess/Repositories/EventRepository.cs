using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransplantationCare.Core.Interfaces.Repositories;
using TransplantationCare.Core.Models.DataBase;

namespace TransplantationCare.DataAccess.Repositories
{
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        public EventRepository(TransplantationCareContext context) : base(context)
        { }

        public async Task<List<Event>> GetAllWithIncludesByUserIdAsync(int userId)
        {
            var _events = await dbSet.Include(e => e.Process)
               .Include(e => e.User)
               .Include(e => e.User.Role)
               .Include(e => e.User.Reviews)
               .Include(e => e.Process.Contract)
               .Include(e => e.Process.Contract.ContractStatus)
               .Include(e => e.Process.Contract.UserContracts)
               .Where(e => e.UserId == userId)
               .ToListAsync();

            return _events;
        }

        public async Task<List<Event>> GetAllWithIncludesByAdminIdAsync(int adminId)
        {
            var _events = await dbSet.Include(e => e.Process)
               .Include(e => e.User)
               .Include(e => e.User.Role)
               .Include(e => e.User.Reviews)
               .Include(e => e.Process.Contract)
               .Include(e => e.Process.Contract.ContractStatus)
               .Include(e => e.Process.Contract.UserContracts)
               .Where(e => e.Process.AdminId == adminId)
               .ToListAsync();

            return _events;
        }

        public async Task<Event> GetWithIncludesByIdAsync(int id)
        {
            var _event = await Task.Run(() => dbSet.Include(e => e.Process)
               .Include(e => e.User)
               .Include(e => e.User.Role)
               .Include(e => e.User.Reviews)
               .Include(e => e.Process.Contract)
               .Include(e => e.Process.Contract.ContractStatus)
               .Include(e => e.Process.Contract.UserContracts)
               .FirstOrDefault(e => e.Id == id));

            return _event;
        }
    }
}
