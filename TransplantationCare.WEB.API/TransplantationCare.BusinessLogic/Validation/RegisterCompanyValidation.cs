using System;
using System.Collections.Generic;
using System.Text;
using TransplantationCare.Core.Interfaces.Repositories;
using TransplantationCare.Core.Interfaces.Validation;
using TransplantationCare.Core.Models.Business;

namespace TransplantationCare.BusinessLogic.Validation
{
    public class RegisterCompanyValidation : IRegisterCompanyValidation
    {
        private readonly ICompanyRepository companyRepository;

        public RegisterCompanyValidation(ICompanyRepository companyRepository)
        {
            this.companyRepository = companyRepository;
        }

        public Dictionary<string, string> Validate(RegisterCompanyModel model)
        {
            var errorsDictionary = new Dictionary<string, string>();
            var company = companyRepository.GetByNameAsync(model.Name).Result;

            if (company != null)
            {
                errorsDictionary.Add(nameof(model.Name), "Компанія з такою назвою вже існує у систумі");
            }

            return errorsDictionary;
        }
    }
}
