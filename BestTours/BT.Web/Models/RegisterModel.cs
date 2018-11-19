using System.ComponentModel.DataAnnotations;

namespace BT.Web.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Поле не заполнено!")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Поле не заполнено!")]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Поле не заполнено!")]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Поле не заполнено!")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        [RegularExpression("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?!.*\\s).*$", ErrorMessage = "Пароль должен содержать символы верхнего и нижнего регистров и не менее одной цифры")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Пароль должен содержать от 6 до 20 символов")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Поле не заполнено!")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Name = "Подтверждение пароля")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Поле не заполнено!")]
        [Display(Name = "Никнейм")]
        [RegularExpression("^[A-Za-z0-9_]{1,15}$", ErrorMessage = "Неверное имя пользователя")]
        public string Name { get; set; }
    }
}