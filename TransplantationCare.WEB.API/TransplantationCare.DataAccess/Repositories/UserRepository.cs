using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransplantationCare.Core.Interfaces.Repositories;
using TransplantationCare.Core.Models.DataBase;

namespace TransplantationCare.DataAccess.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(TransplantationCareContext context) : base(context)
        { }

        public async Task<List<User>> GetAllWithIncludesAsync()
        {
            return await dbSet.Include(u => u.Role)
                .Include(u => u.Company)
                .Include(u => u.Reviews)
                .Include(u => u.UserContracts)
                .Include(u => u.Chats).AsNoTracking().ToListAsync();
        }

        public async Task<User> GetByLogin(string login)
        {
            var user = await Task.Run(() => dbSet.FirstOrDefault(u => u.Login == login));
            if (user != null)
            {
                context.Entry(user).State = EntityState.Detached;
            }

            return user;
        }

        public async Task<User> GetByMail(string mail)
        {
            var user = await Task.Run(() => dbSet.FirstOrDefault(u => u.Mail == mail));
            if (user != null)
            {
                context.Entry(user).State = EntityState.Detached;
            }

            return user;
        }

        public async Task<User> GetWithIncludesByIdAsync(int id)
        {
            var user = await Task.Run(() => dbSet.Include(u => u.Role)
                .Include(u => u.Company)
                .Include(u => u.Reviews)
                .Include(u => u.UserContracts)
                .Include(u => u.Chats).FirstOrDefault(u => u.Id == id));

            context.Entry(user).State = EntityState.Detached;

            return user;
        }

        public async Task<User> GetWithIncludesByLoginAsync(string login)
        {
            var user = await Task.Run(() => dbSet.Include(u => u.Role)
                .Include(u => u.Company)
                .Include(u => u.Reviews)
                .Include(u => u.UserContracts)
                .Include(u => u.Chats).FirstOrDefault(u => u.Login == login));

            context.Entry(user).State = EntityState.Detached;

            return user;
        }
    }
}
