using System.Threading.Tasks;
using TransplantationCare.Core.Models.DataBase;

namespace TransplantationCare.Core.Interfaces.Repositories
{
    public interface IProcessRepository : IRepository<Process>
    {
        Task<Process> GetWithIncludesByIdAsync(int id);
    }
}
