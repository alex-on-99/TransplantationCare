using System;
using System.ComponentModel.DataAnnotations;

namespace TransplantationCare.Core.Models.Business
{
    public class RegisterModel
    {
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Ім'я повинно містити від 2х до 15 букв")]
        [Required(ErrorMessage = "Поле \"Ім'я\" не заповнено.")]
        [Display(Name = "Ім'я")]
        [RegularExpression("^([A-Za-z]+||[А-ЯІЄЩа-яієщ]+)$",
            ErrorMessage = "Ім'я має містити символи Українського або Англійського алфавіту")]
        public string Name { get; set; }

        [StringLength(15, MinimumLength = 3, ErrorMessage = "Прізвище повинно містити від 3х до 15 букв")]
        [Required(ErrorMessage = "Поле \"Прізвище\" не заповнено.")]
        [Display(Name = "Прізвище")]
        [RegularExpression("^([A-Za-z]+||[А-ЯІЄЩа-яієщ]+)$",
            ErrorMessage = "Прізвище має містити символи Українського або Англійського алфавіту")]
        public string SecondName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Поле \"Email\" не заполнено")]
        [RegularExpression("^[a-zA-Z0-9_\\.\\+-]+@[a-zA-Z0-9-]+\\.[a-zA-Z0-9-\\.]+$",
            ErrorMessage = "Некоректний Email")]
        public string Mail { get; set; }

        [Display(Name = "Логін")]
        [Required(ErrorMessage = "Поле \"Логін\" не заповнено")]
        [StringLength(12, MinimumLength = 5, ErrorMessage = "Логін має містити від 5ти до 12ти символів")]
        [RegularExpression("^[a-zA-Z0-9_\\.\\-]+$",
            ErrorMessage = "Невірний логін. Логін може містити символи англійського алфавіту, цифри, символи '_', '-' и '.'")]
        public string Login { get; set; }

        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Поле \"Пароль\" не заповнено")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Підтвердження паролю")]
        [Required(ErrorMessage = "Поле \"Підтвердження паролю\" не заповнено")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Дата народження")]
        [Required(ErrorMessage = "Дата народження не вказана")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [RegularExpression("^[А-ЯІЄЩа-яієщ]{2}[0-9]{6}$", ErrorMessage = "Некоректні Серія або номер паспорту")]
        [Required(ErrorMessage = "Поле \"Серія та номер паспорту\" не заповнено.")]
        [Display(Name = "Серія та номер паспорту")]
        public string Pasport { get; set; }

        [RegularExpression("^[0-9]{9}$", ErrorMessage = "Некоректний номер телефону")]
        [Required(ErrorMessage = "Поле \"Номер телефону\" не заповнено.")]
        [Display(Name = "Номер телефону")]
        public string PhoneNumber { get; set; }
    }
}
