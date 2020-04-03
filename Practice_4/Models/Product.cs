using Practice_4.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Practice_4.Models {
    public class Product : BaseProduct {
       
        [Range(0,int.MaxValue,ErrorMessage ="Количество не может быть отрицательным")]
        [Display(Name="Количество")]
        public new int Amount { get; set; }

        [Required(ErrorMessage ="Тип единиц измерений не задан")]
        [Display(Name="Единица измерения")]
        public MeasureType Measure { get; set; }

        public Product() {}
        public Product(int id,string name,int amount,MeasureType measure) {
            Id = id;
            Name = name;
            Amount = amount;
            Measure = measure;
        }
    }
}