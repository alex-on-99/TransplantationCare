using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TransplantationCare.Core.Interfaces.Repositories;
using TransplantationCare.Core.Models.DataBase;

namespace TransplantationCare.DataAccess.Repositories
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(TransplantationCareContext context) : base(context)
        { }

        public async Task<Role> GetByNameAsync(string name)
        {
            var role = await Task.Run(() => dbSet.FirstOrDefault(r => r.Name == name));
            context.Entry(role).State = EntityState.Detached;

            return role;
        }
    }
}
