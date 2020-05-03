using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TransplantationCare.Core.Models.DataBase
{
    public class Contract
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле \"Орган\" не заповнено.")]
        [Display(Name = "Орган")]
        public string Organ { get; set; }

        [Required(ErrorMessage = "Поле \"Опис\" не заповнено.")]
        [Display(Name = "Опис")]
        public string Description { get; set; }

        /// <summary>
        /// До какого числа необходимо получить орган.
        /// </summary>
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Поле \"Дата отримання\" не заповнено.")]
        [Display(Name = "Дата отримання")]
        public DateTime ReceivingDate { get; set; }

        public DateTime? OrganReceivingDate { get; set; }

        public DateTime? OrganTransferringDate { get; set; }

        public DateTime? BiomaterialsReceivingDate { get; set; }

        public DateTime? BiomaterialsTransferringDate { get; set; }

        public ContractStatus ContractStatus { get; set; }

        public int ContractStatusId { get; set; }

        public List<UserContract> UserContracts { get; set; }

        public List<Chat> Chats { get; set; }

        public Process Process { get; set; }
    }
}
