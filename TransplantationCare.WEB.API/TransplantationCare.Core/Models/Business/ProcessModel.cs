namespace TransplantationCare.Core.Models.Business
{
    public class ProcessModel
    {
        public int Id { get; set; }

        public int ContractId { get; set; }

        public int ProcessStatusId { get; set; }

        public string Organ { get; set; }

        public string Description { get; set; }

        public string StatusName { get; set; }
    }
}
