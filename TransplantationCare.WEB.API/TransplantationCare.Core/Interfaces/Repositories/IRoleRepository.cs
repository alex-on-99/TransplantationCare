using System.Threading.Tasks;
using TransplantationCare.Core.Models.DataBase;

namespace TransplantationCare.Core.Interfaces.Repositories
{
    public interface IRoleRepository : IRepository<Role>
    {
        Task<Role> GetByNameAsync(string name);
    }
}
