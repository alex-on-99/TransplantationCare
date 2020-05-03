using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TransplantationCare.Core.Models.DataBase
{
    public class ContractStatus
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Contract> Contracts { get; set; }
    }
}
