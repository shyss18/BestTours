using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BT.Dom.Entities
{
    public class Tour
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле не заполнено!")]
        [Display(Name = "Название тура")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле не заполнено!")]
        [Display(Name = "Описание тура")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Поле не заполнено!")]
        [Display(Name = "Цена")]
        [Range(0, 5000, ErrorMessage = "Слишком большое значение или отрицательное значение")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Поле не заполнено!")]
        [Display(Name = "Место назначения")]
        public string Destination { get; set; }

        [Required(ErrorMessage = "Поле не заполнено!")]
        [Display(Name = "Дата отправления")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd.MM.yy}", ApplyFormatInEditMode = true)]
        [Remote("ValidateDate", "Tour")]
        public DateTime Date { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
