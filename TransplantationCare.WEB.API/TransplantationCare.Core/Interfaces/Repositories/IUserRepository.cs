using System.Collections.Generic;
using System.Threading.Tasks;
using TransplantationCare.Core.Models.DataBase;

namespace TransplantationCare.Core.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByLogin(string login);

        Task<User> GetByMail(string mail);

        Task<List<User>> GetAllWithIncludesAsync();

        Task<User> GetWithIncludesByIdAsync(int id);

        Task<User> GetWithIncludesByLoginAsync(string login);
    }
}
