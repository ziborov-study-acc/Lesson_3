using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Practice_4.Helpers {
    /// <summary>
    /// Перечисления ед.измерения
    /// </summary>
    public enum MeasureType {
        [Display(Name = "г.")]
        Gram,
        [Display(Name = "кг.")]
        Kilogram,
        [Display(Name = "мл.")]
        Mililiter,
        [Display(Name = "л.")]
        Liter,
        [Display(Name = "шт.")]
        Piece
    }

}