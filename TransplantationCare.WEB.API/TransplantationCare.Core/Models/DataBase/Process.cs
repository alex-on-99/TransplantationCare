using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TransplantationCare.Core.Models.DataBase
{
    public class Process
    {
        [Key]
        public int Id { get; set; }

        public int AdminId { get; set; }

        public Contract Contract { get; set; }

        public int ContractId { get; set; }

        public ProcessStatus ProcessStatus { get; set; }

        public int ProcessStatusId { get; set; }

        public List<Event> Events { get; set; }
    }
}
