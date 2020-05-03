using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TransplantationCare.Core.Interfaces.Repositories;
using TransplantationCare.Core.Models.DataBase;

namespace TransplantationCare.DataAccess.Repositories
{
    public class ProcessRepository : BaseRepository<Process>, IProcessRepository
    {
        public ProcessRepository(TransplantationCareContext context) : base(context)
        { }

        public async Task<Process> GetWithIncludesByIdAsync(int id)
        {
            var process = await Task.Run(() => dbSet.Include(p => p.ProcessStatus)
                .Include(p => p.Events)
                .Include(p => p.Contract.UserContracts)
                .FirstOrDefaultAsync(p => p.Id == id));

            context.Entry(process).State = EntityState.Detached;

            return process;
        }
    }
}
