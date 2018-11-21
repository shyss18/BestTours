using System.ComponentModel.DataAnnotations;

namespace BT.Web.Models
{
    public class AccountModel
    {
        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Данное поле не заполнено!")]
        public string FirstName { get; set; }

        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Данное поле не заполнено!")]
        public string LastName { get; set; }

        public string NickName { get; set; }

        [Display(Name = "Количество валюты")]
        [Required(ErrorMessage = "Данное поле не заполнено!")]
        [Range(0, 5000, ErrorMessage = "Слишком большое значение или отрицательное значение")]
        public decimal Amount { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}