using System;
using System.Collections.Generic;
using TransplantationCare.Core.Models.DataBase;

namespace TransplantationCare.DataAccess.Helpers
{
    internal class DatabaseInitializationHelper
    {
        internal static List<Role> GetBaseRoles()
        {
            return new List<Role>
            {
                new Role()
                {
                    Id = 1,
                    Name = "Client"
                },
                new Role()
                {
                    Id = 2,
                    Name = "Employee"
                },
                new Role()
                {
                    Id = 3,
                    Name = "Admin"
                }
            };
        }

        internal static List<ContractStatus> GetBaseContractStatuses()
        {
            return new List<ContractStatus>
            {
               new ContractStatus
                {
                    Id = 1,
                    Name = "Подано заявку"
                },
                new ContractStatus
                {
                    Id = 2,
                    Name = "Розглядається"
                },
                new ContractStatus
                {
                    Id = 3,
                    Name = "Підтверджено"
                },
                new ContractStatus
                {
                    Id = 4,
                    Name = "Завершено"
                }
            };
        }

        internal static List<ProcessStatus> GetBaseProcessStatuses()
        {
            return new List<ProcessStatus>
            {
               new ProcessStatus
                {
                    Id = 1,
                    Name = "Не почався"
                },
                new ProcessStatus
                {
                    Id = 2,
                    Name = "Очікування біоматеріалів клієнта"
                },
                new ProcessStatus
                {
                    Id = 3,
                    Name = "Доставка біоматеріалів"
                },
                new ProcessStatus
                {
                    Id = 4,
                    Name = "Друкування органу"
                },
                new ProcessStatus
                {
                    Id = 5,
                    Name = "Доставка органу"
                },
                new ProcessStatus
                {
                    Id = 6,
                    Name = "Завершено"
                }
            };
        }

        internal static User GetBaseAdmin()
        {
            return new User
            {
                Id = 1,
                Name = "Олександр",
                SecondName = "Ковальов",
                Mail = "oleksandr.kovalov@nure.ua",
                Login = "aloha",
                DateOfBirth = new DateTime(1999,12,8),
                Pasport = "ПТ567429",
                Password = "123456",
                PhoneNumber = "660459593",
                RoleId = 3
            };
        }
    }
}
