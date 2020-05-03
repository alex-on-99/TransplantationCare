using System;
using System.Collections.Generic;

namespace TransplantationCare.Core.Models.Business
{
    public class ContractModel
    {
        public int Id { get; set; }

        public string Organ { get; set; }

        public string Description { get; set; }

        public DateTime ReceivingDate { get; set; }

        public DateTime? OrganReceivingDate { get; set; }

        public DateTime? OrganTransferringDate { get; set; }

        public DateTime? BiomaterialsReceivingDate { get; set; }

        public DateTime? BiomaterialsTransferringDate { get; set; }

        public int ContractStatusId { get; set; }

        public List<ChatModel> chatModels { get; set; }

        /// public string Client { get; set; }

        /// public string Employee { get; set; }
    }
}
