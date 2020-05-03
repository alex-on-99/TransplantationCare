using System;
using System.Collections.Generic;
using System.Text;

namespace TransplantationCare.Core.Models.Business
{
    public class ChatCreatingModel
    {
        public string Message { get; set; }

        public int ContractId { get; set; }

        public int UserId { get; set; }
    }
}
