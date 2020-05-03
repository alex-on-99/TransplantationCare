using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransplantationCare.Core.Interfaces.Repositories;
using TransplantationCare.Core.Interfaces.Validation;
using TransplantationCare.Core.Models.Business;

namespace TransplantationCare.BusinessLogic.Validation
{
    public class RegisterValidation : IRegisterValidation
    {
        private readonly IUserRepository userRepository;

        public RegisterValidation(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public Dictionary<string,string> Validate(RegisterModel model)
        {
            var validationErrors = new Dictionary<string, string>();

            if (!IsAdult(model.DateOfBirth))
            {
                validationErrors.Add(nameof(model.DateOfBirth),"Некоректна дата народження. наші користувачі мають бути старші 18 та молодше 110 років");
            }

            if (!IsUniqueLogin(model.Login.ToLower()).Result)
            {
                validationErrors.Add(nameof(model.Login), "Користувач с таким логіном вже існує в системі");
            }

            if (!IsUniqueMail(model.Mail.ToLower()).Result)
            {
                validationErrors.Add(nameof(model.Mail), "Email використовується в системі");
            }

            if (!ArePasswordsSame(model.Password, model.ConfirmPassword))
            {
                validationErrors.Add(nameof(model.ConfirmPassword), "Паролі не співпадають");
            }

            return validationErrors;
        }

        private bool IsAdult(DateTime dateOfBirth)
        {
            return (dateOfBirth > DateTime.Now.AddYears(-110) && dateOfBirth < DateTime.Now.AddYears(-18));
        }

        private async Task<bool> IsUniqueLogin(string login)
        {
            var user = await userRepository.GetByLogin(login);

            return user == null;
        }

        private async Task<bool> IsUniqueMail(string mail)
        {
            var user = await userRepository.GetByMail(mail);

            return user == null;
        }

        private bool ArePasswordsSame(string password, string confirmPasswod)
        {
            return password == confirmPasswod;
        }
    }
}
