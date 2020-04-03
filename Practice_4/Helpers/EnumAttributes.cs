using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Practice_4.Helpers {
   /// <summary>
   /// Класс для получения Display(Name) атрибута для перечисления
   /// 
   /// </summary>
    public static class EnumAttributes {
        public static string GetDisplayName(this Enum value) {
            var attribute = GetDisplayAttribute(value);
            return attribute != null ? attribute.Name : value.ToString();
        }

        private static DisplayAttribute GetDisplayAttribute(object value) {
            Type type = value.GetType();
            if (!type.IsEnum)
            {
                throw new ArgumentException(string.Format("Type {0} is not an enum", type));
            }

            var field = type.GetField(value.ToString());
            return field?.GetCustomAttribute<DisplayAttribute>();
        }
    }
}