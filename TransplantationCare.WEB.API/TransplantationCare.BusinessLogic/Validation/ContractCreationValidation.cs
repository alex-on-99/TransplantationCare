using System;
using System.Collections.Generic;
using System.Text;
using TransplantationCare.Core.Interfaces.Validation;
using TransplantationCare.Core.Models.Business;

namespace TransplantationCare.BusinessLogic.Validation
{
    public class ContractCreationValidation : IContractCreationValidation
    {
        public Dictionary<string, string> Validate(ContractCreationModel model)
        {
            var errorsDictionary = new Dictionary<string, string>();

            if (model.ReceivingDate <  DateTime.Now.AddMonths(3))
            {
                errorsDictionary.Add(nameof(model.ReceivingDate), "Отримати орган можна не менше ніж через 3 місяці");
            }

            return errorsDictionary;
        }
    }
}
