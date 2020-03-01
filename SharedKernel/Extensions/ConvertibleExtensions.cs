using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace SharedKernel.Extensions
{
    public static class ConvertibleExtensions
    {
        public static string GetDescription<T>(this T e) where T : IConvertible
        {
            if (!(e is Enum)) return null; // could also return string.Empty
            Type type = e.GetType();
            Array values = Enum.GetValues(type);

            foreach (int val in values)
            {
                if (val != e.ToInt32(CultureInfo.InvariantCulture)) continue;
                var memInfo = type.GetMember(type.GetEnumName(val));
                var descriptionAttribute = memInfo[0]
                    .GetCustomAttributes(typeof(DescriptionAttribute), false)
                    .FirstOrDefault() as DescriptionAttribute;

                if (descriptionAttribute != null)
                    return descriptionAttribute.Description;
            }

            throw new Exception("this enum value does not have description attribute");
        }
    }
}