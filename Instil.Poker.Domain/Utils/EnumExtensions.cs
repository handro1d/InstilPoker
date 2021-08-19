using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Instil.Poker.Domain.Utils
{
    public static class EnumUtility
    {
        public static string GetDescription<TEnum>(this TEnum value)
            where TEnum : Enum
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));

            return attribute != null ? attribute.Description : null;
        }

        public static IEnumerable<string> GetAllDescriptions<TEnum>()
            where TEnum : Enum
        {
            return typeof(TEnum)
                .GetEnumValues()
                .OfType<TEnum>()
                .Select(value => value.GetDescription());
        }

        public static TEnum TryGetFromDescription<TEnum>(string description)
            where TEnum : Enum
        {
            var enumValues = typeof(TEnum).GetEnumValues().Cast<TEnum>();

            return enumValues.FirstOrDefault(enumValue =>
                enumValue.GetDescription().Equals(description, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}