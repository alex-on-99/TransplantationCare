using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransplantationCare.Core.Interfaces.Repositories;
using TransplantationCare.Core.Interfaces.Services;
using TransplantationCare.Core.Models.Business;
using TransplantationCare.Core.Models.DataBase;

namespace TransplantationCare.BusinessLogic.Services
{
    public class ContractService : IContractService
    {
        private readonly IContractRepository contractRepository;
        private readonly IUserContractRepository userContractRepository;
        private readonly IChatRepository chatRepository;

        public ContractService(
            IContractRepository contractRepository, 
            IUserContractRepository userContractRepository,
            IChatRepository chatRepository)
        {
            this.contractRepository = contractRepository;
            this.userContractRepository = userContractRepository;
            this.chatRepository = chatRepository;
        }

        public async Task CreateContract(ContractCreationModel contractModel)
        {
            var contract = new Contract
            {
                Organ = contractModel.Organ,
                ReceivingDate = contractModel.ReceivingDate,
                Description = contractModel.Description,
                ContractStatusId = 1
            };
            await contractRepository.AddAsync(contract);

            var userContract = new UserContract
            {
                UserId = contractModel.CreatorId,
                ContractId = contract.Id
            };
            await userContractRepository.AddAsync(userContract);
        }

        public async Task<List<ContractModel>> GetAllNotRevivedContracts()
        {
            var contracts = await contractRepository.GetAllWithIncludesAsync();

            var currentContracts = contracts.Where(c => c.ContractStatus.Id == 1).ToList();
            var contractModelList = new List<ContractModel>();

            foreach (var item in currentContracts)
            {
                contractModelList.Add(new ContractModel
                {
                    Id = item.Id,
                    ContractStatusId = item.ContractStatusId,
                    BiomaterialsReceivingDate = item.BiomaterialsReceivingDate,
                    BiomaterialsTransferringDate = item.BiomaterialsTransferringDate,
                    Description = item.Description,
                    Organ = item.Organ,
                    OrganReceivingDate = item.OrganReceivingDate,
                    OrganTransferringDate = item.OrganTransferringDate,
                    ReceivingDate = item.ReceivingDate,
                });
            }

            return contractModelList;
        }

        public async Task<ContractModel> GetContract(int id)
        {
            var contract = await contractRepository.GetWithIncludesByIdAsync(id);
            var chatModels = new List<ChatModel>();
            contract.Chats.ForEach(c => chatModels.Add(new ChatModel {
                ContractId = c.ContractId,
                Message = c.Message,
                UserId = c.UserId,
                WritingDate = c.WritingDate
            }));

            var contractModel = new ContractModel
            {
                Id = contract.Id,
                ContractStatusId = contract.ContractStatusId,
                BiomaterialsReceivingDate = contract.BiomaterialsReceivingDate,
                BiomaterialsTransferringDate = contract.BiomaterialsTransferringDate,
                Description = contract.Description,
                Organ = contract.Organ,
                OrganReceivingDate = contract.OrganReceivingDate,
                OrganTransferringDate = contract.OrganTransferringDate,
                ReceivingDate = contract.ReceivingDate,
                chatModels = chatModels
            };

            return contractModel;
        }

        public async Task<List<ContractModel>> GetContractsByUserId(int id)
        {
            var userContracts = await userContractRepository.GetAllWithIncludesByUserIdAsync(id);
            var contractModels = new List<ContractModel>();

            foreach (var item in userContracts)
            {
                contractModels.Add(
                    new ContractModel
                    {
                        Id = item.Contract.Id,
                        ContractStatusId = item.Contract.ContractStatusId,
                        BiomaterialsReceivingDate = item.Contract.BiomaterialsReceivingDate,
                        BiomaterialsTransferringDate = item.Contract.BiomaterialsTransferringDate,
                        Description = item.Contract.Description,
                        Organ = item.Contract.Organ,
                        OrganReceivingDate = item.Contract.OrganReceivingDate,
                        OrganTransferringDate = item.Contract.OrganTransferringDate,
                        ReceivingDate = item.Contract.ReceivingDate
                    });
            }

            return contractModels;
        }

        public async Task RemoveContract(int id)
        {
            var contract = await contractRepository.GetByIdAsync(id);
            await contractRepository.RemoveAsync(contract);
        }

        public async Task UpdateContract(ContractUpdateModel contractModel)
        {
            var contract = await contractRepository.GetByIdAsync(contractModel.Id);

            contract.OrganReceivingDate = contractModel.OrganReceivingDate;
            contract.OrganTransferringDate = contractModel.OrganTransferringDate;
            contract.BiomaterialsReceivingDate = contractModel.BiomaterialsReceivingDate;
            contract.BiomaterialsTransferringDate = contractModel.BiomaterialsTransferringDate;

            await contractRepository.UpdateAsync(contract);
        }

        public async Task AddUserContract(UserContractCreationModel model)
        {
            var userContract = new UserContract
            {
                UserId = model.UserId,
                ContractId = model.ContractId
            };
             
            await userContractRepository.AddAsync(userContract);
            await ChangeContractStatus(model.ContractId, 2);
        }

        public async Task ConfirmContract(int contractid)
        {
            await ChangeContractStatus(contractid, 3);
        }

        public async Task EndContract(int contractid)
        {
            await ChangeContractStatus(contractid, 4);
        }

        public async Task AddChatMessage(ChatCreatingModel chatModel)
        {
            var chat = new Chat
            {
                Message = chatModel.Message,
                UserId = chatModel.UserId,
                ContractId = chatModel.ContractId,
                WritingDate = DateTime.Now
            };

            await chatRepository.AddAsync(chat);
        }

        private async Task ChangeContractStatus(int contractid, int statusId)
        {
            var contract = await contractRepository.GetByIdAsync(contractid);
            contract.ContractStatusId = statusId;

            await contractRepository.UpdateAsync(contract);
        }
    }
}
