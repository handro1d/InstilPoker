using System;
using System.Collections.Generic;
using System.Linq;

namespace Instil.Poker.Tests.Common
{
    public static class EnumUtility
    {
        /// <summary>
        /// Return random value from enum
        /// </summary>
        /// <param name="exclusions">Values which should not be returned.</param>
        /// <typeparam name="TEnum">Enum type to use.</typeparam>
        /// <returns>Random enum value of type <cref="TEnum" /></returns>
        public static TEnum GetRandomEnumValue<TEnum>(IEnumerable<TEnum> exclusions = null)
            where TEnum : Enum
        {
            var random = new Random();
            var enumValues = (TEnum[])Enum.GetValues(typeof(TEnum));

            var possibleValues = exclusions == null
                ? enumValues
                : (TEnum[])enumValues.Except(exclusions).ToArray();

            var randomIndex = random.Next(0, possibleValues.Count());

            return possibleValues[randomIndex];
        }
    }
}