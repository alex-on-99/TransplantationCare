using System.ComponentModel.DataAnnotations;

namespace TransplantationCare.Core.Models.Business
{
    public class RegisterEmployeeModel : RegisterModel
    {
        [Required(ErrorMessage = "Поле \"Компанія\" не заповнено.")]
        [Display(Name = "Компанія")]
        public int CompanyId { get; set; }
    }
}
