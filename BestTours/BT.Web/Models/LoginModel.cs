using System.ComponentModel.DataAnnotations;

namespace BT.Web.Models
{
    public class LoginModel
    {
        [Required]
        public string NickName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}