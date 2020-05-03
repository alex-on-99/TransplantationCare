using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TransplantationCare.BusinessLogic.Extensions;
using TransplantationCare.Core.Constants;
using TransplantationCare.Core.Interfaces.Repositories;
using TransplantationCare.Core.Interfaces.Services;
using TransplantationCare.Core.Models.Business;
using TransplantationCare.Core.Models.DataBase;

namespace TransplantationCare.BusinessLogic.Services
{
    public class EmployeeAccountService : IEmployeeAccountService
    {
        private readonly IUserRepository userRepository;
        private readonly ICompanyRepository companyRepository;
        private readonly IRoleRepository roleRepository;

        public EmployeeAccountService(
            IUserRepository userRepository,
            ICompanyRepository companyRepository,
            IRoleRepository roleRepository)
        {
            this.userRepository = userRepository;
            this.companyRepository = companyRepository;
            this.roleRepository = roleRepository;
        }

        public async Task RegisterCompany(RegisterCompanyModel companyModel)
        {
            var company = new Company
            {
                Name = companyModel.Name,
                Description = companyModel.Description,
                Location = companyModel.Location
            };

            await companyRepository.AddAsync(company);
        }

        public async Task RegisterEmployee(RegisterEmployeeModel employeeModel)
        {
            var role = await roleRepository.GetByNameAsync(RoleConstants.EmployeeRole);

            var user = new User
            {
                Name = employeeModel.Name,
                SecondName = employeeModel.SecondName,
                Login = employeeModel.Login.ToLower(),
                DateOfBirth = employeeModel.DateOfBirth,
                Mail = employeeModel.Mail.ToLower(),
                PhoneNumber = employeeModel.PhoneNumber,
                Pasport = employeeModel.Pasport.ToUpper(),
                Password = employeeModel.Password.EncryptMd5(),
                CompanyId = employeeModel.CompanyId,
                RoleId = role.Id
            };

            await userRepository.AddAsync(user);
        }
    }
}
