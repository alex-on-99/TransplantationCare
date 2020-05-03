using System;
using System.Threading.Tasks;
using TransplantationCare.Core.Interfaces.Repositories;
using TransplantationCare.Core.Interfaces.Services;
using TransplantationCare.Core.Models.Business;
using TransplantationCare.Core.Models.DataBase;
using TransplantationCare.BusinessLogic.Extensions;
using TransplantationCare.Core.Constants;

namespace TransplantationCare.BusinessLogic.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository userRepository;
        private readonly IRoleRepository roleRepository;

        public AccountService(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
        }

        public async Task RegisterUser(RegisterModel registerModel)
        {
            var role = await roleRepository.GetByNameAsync(RoleConstants.ClientRole);

            var user = new User
            {
                Name = registerModel.Name,
                SecondName = registerModel.SecondName,
                Login = registerModel.Login.ToLower(),
                DateOfBirth = registerModel.DateOfBirth,
                Mail = registerModel.Mail.ToLower(),
                PhoneNumber = registerModel.PhoneNumber,
                Pasport = registerModel.Pasport.ToUpper(),
                Password = registerModel.Password.EncryptMd5(),
                RoleId = role.Id
            };

            await userRepository.AddAsync(user);
        }

        public async Task<User> Login(LoginModel model)
        {
            return await userRepository.GetWithIncludesByLoginAsync(model.Login);
        }
    }
}
