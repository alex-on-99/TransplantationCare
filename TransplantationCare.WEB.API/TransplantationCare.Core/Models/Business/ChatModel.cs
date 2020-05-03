using System;
using System.Collections.Generic;
using System.Text;

namespace TransplantationCare.Core.Models.Business
{
    public class ChatModel
    {
        public string Message { get; set; }

        public int ContractId { get; set; }

        public int UserId { get; set; }

        public DateTime WritingDate { get; set; }
    }
}
