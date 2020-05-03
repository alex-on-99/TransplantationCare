using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransplantationCare.Core.Interfaces.Repositories;
using TransplantationCare.Core.Models.DataBase;

namespace TransplantationCare.DataAccess.Repositories
{
    public class ChatRepository : BaseRepository<Chat>, IChatRepository
    {
        public ChatRepository(TransplantationCareContext context) : base(context)
        { }

        public async Task<List<Chat>> GetAllWithIncludesByContractIdAsync(int contractId)
        {
            var chats = await dbSet.Include(us => us.Contract)
               .Include(us => us.User)
               .Include(us => us.User.Role)
               .Include(us => us.User.Reviews)
               .Include(us => us.Contract.Process)
               .Include(us => us.Contract.Process.ProcessStatus)
               .Include(us => us.Contract.Process.Events)
               .Where(u => u.ContractId == contractId)
               .ToListAsync();

            return chats;
        }
    }
}
