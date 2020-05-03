using System.Collections.Generic;
using System.Threading.Tasks;
using TransplantationCare.Core.Models.Business;

namespace TransplantationCare.Core.Interfaces.Services
{
    public interface IUserService
    {
        Task<List<UserModel>> GetAllUsers();

        Task<UserModel> GetUser(int id);

        Task<UserModel> GetUserByLogin(string login);
    }
}
