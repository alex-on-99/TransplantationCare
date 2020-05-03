using System.Threading.Tasks;
using TransplantationCare.Core.Models.Business;

namespace TransplantationCare.Core.Interfaces.Services
{
    public interface IEmployeeAccountService
    {
        Task RegisterCompany(RegisterCompanyModel companyModel);

        Task RegisterEmployee(RegisterEmployeeModel employeeModel);
    }
}
