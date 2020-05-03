using System.ComponentModel.DataAnnotations;

namespace TransplantationCare.Core.Models.DataBase
{
    public class Role
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
