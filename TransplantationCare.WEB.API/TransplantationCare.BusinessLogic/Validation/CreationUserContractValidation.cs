using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TransplantationCare.Core.Interfaces.Repositories;
using TransplantationCare.Core.Interfaces.Validation;
using TransplantationCare.Core.Models.Business;

namespace TransplantationCare.BusinessLogic.Validation
{
    public class CreationUserContractValidation : ICreationUserContractValidation
    {
        private readonly IUserContractRepository userContractRepository;
        private readonly IUserRepository userRepository;

        public CreationUserContractValidation(
            IUserContractRepository userContractRepository,
            IUserRepository userRepository)
        {
            this.userContractRepository = userContractRepository;
            this.userRepository = userRepository;
        }

        public  Dictionary<string, string> Validate(UserContractCreationModel model)
        {
            var errorsDictionary = new Dictionary<string, string>();

            string userRole = userRepository.GetWithIncludesByIdAsync(model.UserId)
                .Result.Role.Name;
            var userContracts = userContractRepository.GetAllWithIncludesByContractIdAsync(model.ContractId).Result;
            
            if (userContracts == null)
            {
                errorsDictionary.Add(nameof(model.ContractId), "Контракта з таким ідентифікатором не існує");

            }
            else
            {
                if (userContracts.Where(uc => uc.User.Role.Name.Equals(userRole)).Count() > 0)
                {
                    errorsDictionary.Add(nameof(model.UserId), $"На даний контракт вже підписаний {userRole}.");
                }
            }

            return errorsDictionary;
        }
    }
}
