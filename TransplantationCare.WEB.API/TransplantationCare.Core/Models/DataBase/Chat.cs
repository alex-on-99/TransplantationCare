using System;
using System.ComponentModel.DataAnnotations;

namespace TransplantationCare.Core.Models.DataBase
{
    public class Chat
    {
        [Key]
        public int Id { get; set; }

        public string Message { get; set; }

        public DateTime WritingDate { get; set; }

        public User User { get; set; }

        public int UserId { get; set; }

        public Contract Contract { get; set; }

        public int ContractId { get; set; }
    }
}
