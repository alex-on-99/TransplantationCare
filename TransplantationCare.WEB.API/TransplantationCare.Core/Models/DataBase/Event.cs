using System;
using System.ComponentModel.DataAnnotations;

namespace TransplantationCare.Core.Models.DataBase
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        public string Text { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime ExecutionTime { get; set; }

        public User User { get; set; }

        public int UserId { get; set; }

        public Process Process { get; set; }

        public int ProcessId { get; set; }
    }
}
