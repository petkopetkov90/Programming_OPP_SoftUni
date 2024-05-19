using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ValidationAttributes.Attributes;

namespace ValidationAttributes.Utilities;

public static class Validator
{
    public static bool IsValid(object obj)
    {
        PropertyInfo[] properties = obj.GetType().GetProperties().Where(p => p.CustomAttributes
                .Any(ca => typeof(MyValidationAttribute).IsAssignableFrom(ca.AttributeType)))
            .ToArray();

        foreach (PropertyInfo property in properties)
        {
            IEnumerable<Attribute> attributes = property.GetCustomAttributes().Where(ca => typeof(MyValidationAttribute).IsAssignableFrom(ca.GetType()));

            foreach (MyValidationAttribute attribute in attributes)
            {
                if (!attribute.IsValid(property.GetValue(obj)))
                {
                    return false;
                }
            }
        }

        return true;
    }
}
