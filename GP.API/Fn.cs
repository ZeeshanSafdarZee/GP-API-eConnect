using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GP.API
{
    public static class Fn
    {
        public static TSelf ReplaceNullOrEmptyStringProperties<TSelf>(this TSelf input, string replacement)
        {
            var stringProperties = input.GetType().GetProperties()
                .Where(p => p.PropertyType == typeof(string));

            foreach (var stringProperty in stringProperties)
            {
                //Only update properties that can be written
                if (stringProperty.CanWrite)
                {
                    string currentValue = (string)stringProperty.GetValue(input, null);
                    if (string.IsNullOrEmpty(currentValue))
                    {
                        stringProperty.SetValue(input, replacement, null);
                    }
                }
            }
            return input;
        }
    }
}
