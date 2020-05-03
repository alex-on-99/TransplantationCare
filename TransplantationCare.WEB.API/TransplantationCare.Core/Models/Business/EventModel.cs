using System;

namespace TransplantationCare.Core.Models.Business
{
    public class EventModel
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime ExecutionTime { get; set; }

        public int UserId { get; set; }

        public int ProcessId { get; set; }
    }
}
