using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TransplantationCare.Core.Models.DataBase
{
    public class ProcessStatus
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Process> Processes { get; set; }
    }
}
