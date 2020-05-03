
using System.ComponentModel.DataAnnotations;

namespace TransplantationCare.Core.Models.Business
{
    public class LoginModel
    {
        [Display(Name = "Логін")]
        [Required(ErrorMessage = "Поле \"Логін\" не заповнено")]
        public string Login { get; set; }

        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Поле \"Пароль\" не заповнено")]
        public string Password { get; set; }
    }
}
