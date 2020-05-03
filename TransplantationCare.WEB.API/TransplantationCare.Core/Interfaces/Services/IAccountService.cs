using System.Threading.Tasks;
using TransplantationCare.Core.Models.Business;
using TransplantationCare.Core.Models.DataBase;

namespace TransplantationCare.Core.Interfaces.Services
{
    public interface IAccountService
    {
        Task RegisterUser(RegisterModel registerModel);

        Task<User> Login(LoginModel loginModel);
    }
}
