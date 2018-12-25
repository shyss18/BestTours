using System.ComponentModel.DataAnnotations;

namespace BT.Web.Models {
    public class LoginModel 
    {
        [Required (ErrorMessage = "Поле не заполнено!")]
        [Display (Name = "Никнейм")]
        public string NickName { get; set; }

        [Required (ErrorMessage = "Поле не заполнено!")]
        [DataType (DataType.Password)]
        [Display (Name = "Пароль")]
        public string Password { get; set; }
    }
}