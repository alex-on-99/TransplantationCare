using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransplantationCare.Core.Interfaces.Repositories;
using TransplantationCare.Core.Models.DataBase;

namespace TransplantationCare.DataAccess.Repositories
{
    public class UserContractRepository : BaseRepository<UserContract>, IUserContractRepository
    {
        public UserContractRepository(TransplantationCareContext context) : base(context)
        { }

        public async Task<List<UserContract>> GetAllWithIncludesAsync()
        {
            return await dbSet.Include(us => us.Contract)
               .Include(us => us.User)
               .Include(us => us.User.Role)
               .Include(us => us.User.Reviews)
               .Include(us => us.Contract.Process)
               .Include(us => us.Contract.Process.ProcessStatus)
               .Include(us => us.Contract.Process.Events)
               .AsNoTracking().ToListAsync();
        }

        public async Task<List<UserContract>> GetAllWithIncludesByUserIdAsync(int id)
        {
            var userContracts = await dbSet.Include(us => us.Contract)
               .Include(us => us.User)
               .Include(us => us.User.Role)
               .Include(us => us.User.Reviews)
               .Include(us => us.Contract.Process)
               .Include(us => us.Contract.Process.ProcessStatus)
               .Include(us => us.Contract.Process.Events)
               .Where(u => u.UserId == id)
               .ToListAsync();

            return userContracts;
        }

        public async Task<UserContract> GetWithIncludesByIdAsync(int id)
        {
            var userContract = await Task.Run(() => dbSet.Include(us => us.Contract)
               .Include(us => us.User)
               .Include(us => us.User.Role)
               .Include(us => us.User.Reviews)
               .Include(us => us.Contract.Process)
               .Include(us => us.Contract.Process.ProcessStatus)
               .Include(us => us.Contract.Process.Events)
               .FirstOrDefault(u => u.Id == id));

            return userContract;
        }

        public async Task<List<UserContract>> GetAllWithIncludesByContractIdAsync(int contractId)
        {
            var userContracts = await dbSet.Include(us => us.Contract)
               .Include(us => us.User)
               .Include(us => us.User.Role)
               .Include(us => us.User.Reviews)
               .Include(us => us.Contract.Process)
               .Include(us => us.Contract.Process.ProcessStatus)
               .Include(us => us.Contract.Process.Events)
               .Where(u => u.ContractId == contractId)
               .ToListAsync();

            return userContracts;
        }
    }
}
