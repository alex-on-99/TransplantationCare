using System.Threading.Tasks;
using TransplantationCare.Core.Models.DataBase;

namespace TransplantationCare.Core.Interfaces.Repositories
{
    public interface ICompanyRepository : IRepository<Company>
    {
        Task<Company> GetByNameAsync(string name);
    }
}
