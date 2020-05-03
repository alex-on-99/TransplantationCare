using System;
using System.Collections.Generic;
using System.Text;

namespace TransplantationCare.Core.Models.Business
{
    public class ContractUpdateModel
    {
        public int Id { get; set; }

        public DateTime? OrganReceivingDate { get; set; }

        public DateTime? OrganTransferringDate { get; set; }

        public DateTime? BiomaterialsReceivingDate { get; set; }

        public DateTime? BiomaterialsTransferringDate { get; set; }
    }
}
