using System;
using System.Collections.Generic;
using System.Text;

namespace TransplantationCare.Core.Models.Business
{
    public class UserModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

       public string SecondName { get; set; }

        public string Mail { get; set; }

        public string Login { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Pasport { get; set; }

        public string PhoneNumber { get; set; }

        public int RoleId { get; set; }

        public int? CompanyId { get; set; }
        
        public List<ReviewCreationModel> ReviewModels { get; set; }
    }
}
