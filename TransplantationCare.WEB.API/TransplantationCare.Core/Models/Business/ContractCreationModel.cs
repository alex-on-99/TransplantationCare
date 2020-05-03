using System;
using System.ComponentModel.DataAnnotations;

namespace TransplantationCare.Core.Models.Business
{
    public class ContractCreationModel
    {
        [Required(ErrorMessage = "Поле \"Орган\" не заповнено.")]
        [Display(Name = "Орган")]
        public string Organ { get; set; }

        /// <summary>
        /// До какого числа необходимо получить орган.
        /// </summary>
        [Required(ErrorMessage = "Поле \"Дата отримання\" не заповнено.")]
        [Display(Name = "Дата отримання")]
        [DataType(DataType.Date)]
        public DateTime ReceivingDate { get; set; }

        [Required(ErrorMessage = "Поле \"Опис\" не заповнено.")]
        [Display(Name = "Опис")]
        public string Description { get; set; }

        public int CreatorId { get; set; }
    }
}
