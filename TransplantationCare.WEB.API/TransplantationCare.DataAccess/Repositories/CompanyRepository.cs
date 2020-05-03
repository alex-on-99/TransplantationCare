using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TransplantationCare.Core.Interfaces.Repositories;
using TransplantationCare.Core.Models.DataBase;

namespace TransplantationCare.DataAccess.Repositories
{
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(TransplantationCareContext context) : base(context)
        { }

        public async Task<Company> GetByNameAsync(string name)
        {
            var company = await Task.Run(() => dbSet.FirstOrDefault(u => u.Name == name));
            if (company != null)
            {
                context.Entry(company).State = EntityState.Detached;
            }

            return company;
        }
    }
}
