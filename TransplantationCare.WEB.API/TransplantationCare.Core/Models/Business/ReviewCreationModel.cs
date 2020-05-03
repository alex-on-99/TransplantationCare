using System;
using System.ComponentModel.DataAnnotations;

namespace TransplantationCare.Core.Models.Business
{
    public class ReviewCreationModel
    {
        [Required(ErrorMessage = "Поле \"Відгук\" не заповнено.")]
        [Display(Name = "Відгук")]
        public string Message { get; set; }

        public string ReviewerLogin { get; set; }

        public DateTime DateTimeReview { get; set; }

        public int UserId { get; set; }
    }
}
