using System.Collections.Generic;
using TransplantationCare.Core.Interfaces.Repositories;
using TransplantationCare.Core.Interfaces.Validation;
using TransplantationCare.Core.Models.Business;
using TransplantationCare.BusinessLogic.Extensions;

namespace TransplantationCare.BusinessLogic.Validation
{
    public class LoginValidation : ILoginValidation
    {
        private readonly IUserRepository userRepository;

        public LoginValidation(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public Dictionary<string, string> Validate(LoginModel model)
        {
            var errorsDictionary = new Dictionary<string, string>();
            var user = userRepository.GetByLogin(model.Login).Result;

            if (user == null)
            {
                errorsDictionary.Add("loginError", "Некоректний логін або пароль");
            }
            else
            {
                if (model.Password.EncryptMd5() != user.Password)
                {
                    errorsDictionary.Add("loginError", "Некоректний логін або пароль");
                }
            }

            return errorsDictionary;
        }

    }
}
