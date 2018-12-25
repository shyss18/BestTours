using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BT.Dom.Entities
{
    public class Hotel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Название отеля")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Поле не заполнено!")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Слишком маленькое название гостиницы")]
        public string Name { get; set; }

        [Display(Name = "Адрес")]
        [Required(ErrorMessage = "Поле не заполнено!")]
        [StringLength(100, MinimumLength = 20, ErrorMessage = "Введите полный адрес гостиницы")]
        public string Address { get; set; }

        [Display(Name = "Номер")]
        [Required(ErrorMessage = "Поле не заполнено!")]
        [RegularExpression("[\\+]\\d{3}[\\-][\\(]\\d{2}[\\)][\\-]\\d{3}[\\-]\\d{2}[\\-]\\d{2}", ErrorMessage = "Введите номер в формате +xxx-(xx)-xxx-xx-xx")]
        public string Phone { get; set; }

        public virtual ICollection<Tour> Tours { get; set; }
    }
}
