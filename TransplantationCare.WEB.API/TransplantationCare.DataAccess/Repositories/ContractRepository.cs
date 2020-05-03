using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransplantationCare.Core.Interfaces.Repositories;
using TransplantationCare.Core.Models.DataBase;

namespace TransplantationCare.DataAccess.Repositories
{
    public class ContractRepository : BaseRepository<Contract>, IContractRepository
    {
        public ContractRepository(TransplantationCareContext context) : base(context)
        { }

        public async Task<List<Contract>> GetAllWithIncludesAsync()
        {
            return await dbSet.Include(c => c.ContractStatus)
               .Include(c => c.UserContracts)
               .Include(c => c.Chats)
               .Include(c => c.Process)
               .Include(c => c.Process.Events)
               .Include(c => c.Process.ProcessStatus)
               .AsNoTracking().ToListAsync();
        }

        public async Task<Contract> GetWithIncludesByIdAsync(int id)
        {
            var contract = await Task.Run(() => dbSet.Include(c => c.ContractStatus)
               .Include(c => c.UserContracts)
               .Include(c => c.Chats)
               .Include(c => c.Process)
               .Include(c => c.Process.Events)
               .Include(c => c.Process.ProcessStatus)
               .FirstOrDefault(u => u.Id == id));

            return contract;
        }
    }
}
