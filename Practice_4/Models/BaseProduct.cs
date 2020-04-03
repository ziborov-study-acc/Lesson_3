using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Practice_4.Models {
    public class BaseProduct {
        [Key]
        public int Id { get; set; }

        [Display(Name="Название продукта")]
        [Required(ErrorMessage ="Название продукта не может быть пустым")]
        [RegularExpression(@"^[а-яА-ЯёЁa-zA-Z]+$", ErrorMessage = "Название должно включать буквенные символы")]
        public string Name { get; set; }

        [Display(Name = "Количество")]
        [Required(ErrorMessage ="Количество продуктов не может быть пустым")]
        public string Amount { get; set; }

        public BaseProduct() {}
        public BaseProduct(int id,string name,string amount) {
            Id = id;
            Name = name;
            Amount = amount;
        }
    }
}