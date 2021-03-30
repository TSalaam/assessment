using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Zapper.Payment.Api.Extensions {

    public static class EnumerationExtensions {

        public static string Description(this Enum value) {

            var field = value.GetType().GetField(value.ToString());
            var attributes = field.GetCustomAttributes(false);

            dynamic displayAttribute = null;

            if (attributes.Any()) {
                displayAttribute = attributes.ElementAt(0);
            }

            return displayAttribute?.Description ?? "Description not found";
        }

        public static T GetEnumFromDescription<T>(this string description) {

            var type = typeof(T);

            if (!type.IsEnum) throw new InvalidOperationException();

            foreach (var field in type.GetFields()) {

                var attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;

                if (attribute != null) {
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                }
                else {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }

            throw new ArgumentException("Argument not found", "Description");
        }
    }
}
