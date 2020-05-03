using System.ComponentModel.DataAnnotations;

namespace TransplantationCare.Core.Models.Business
{
    public class RegisterCompanyModel
    {
        [Required(ErrorMessage = "Поле \"Назва\" не заповнено.")]
        [Display(Name = "Назва")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле \"Опис\" не заповнено.")]
        [Display(Name = "Опис")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Поле \"Розсташування\" не заповнено.")]
        [Display(Name = "Розсташування")]
        public string Location { get; set; }
    }
}
