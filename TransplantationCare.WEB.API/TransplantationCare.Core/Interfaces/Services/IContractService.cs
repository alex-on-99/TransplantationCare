using System.Collections.Generic;
using System.Threading.Tasks;
using TransplantationCare.Core.Models.Business;
using TransplantationCare.Core.Models.DataBase;

namespace TransplantationCare.Core.Interfaces.Services
{
    public interface IContractService
    {
        Task CreateContract(ContractCreationModel contractModel);

        Task<List<ContractModel>> GetAllNotRevivedContracts();

        Task<ContractModel> GetContract(int id);

        Task RemoveContract(int id);

        Task UpdateContract(ContractUpdateModel contractModel);

        Task AddUserContract(UserContractCreationModel userContractModel);

        Task<List<ContractModel>> GetContractsByUserId(int id);

        Task AddChatMessage(ChatCreatingModel chatModel);

        Task ConfirmContract(int contractid);

        Task EndContract(int contractid);
    }
}
