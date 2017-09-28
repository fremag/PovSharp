using System;
using System.Collections.Generic;
using System.Linq;

namespace PovSharp.Core
{
    public static class PovHelpers
    {
        private static readonly SortedDictionary<int, string> dico = new SortedDictionary<int, string>();

        public static string BuildPovCode(this object obj)
        {
            var props = obj.GetType()
            .GetProperties()
            .Where(propInfo => propInfo.GetCustomAttributes(typeof(PovFieldAttribute), true).Any());
            var dico = new SortedDictionary<int, string>();

            foreach (var prop in props)
            {
                var att = prop.GetCustomAttributesData().FirstOrDefault(data => data.AttributeType == typeof(PovFieldAttribute));
                var idx = (int)(att.ConstructorArguments[0].Value);

                var propValue = prop.GetValue(obj);
                var povElement = propValue as AbstractPovElement;
                string povCode = null;
                if (povElement != null)
                {
                    povCode = GetPovCode(povElement);
                }
                else if (propValue != null && propValue.GetType().IsEnum)
                {
                    povCode = GetEnumPovCode(propValue);
                }

                if (!string.IsNullOrEmpty(povCode))
                {
                    var beforeArg = att.NamedArguments.FirstOrDefault(arg => arg.MemberName == nameof(PovFieldAttribute.Before)).TypedValue.Value as string;
                    var afterArg = att.NamedArguments.FirstOrDefault(arg => arg.MemberName == nameof(PovFieldAttribute.After)).TypedValue.Value as string;
                    if (!string.IsNullOrEmpty(beforeArg) && !string.IsNullOrEmpty(povCode))
                    {
                        povCode = beforeArg + povCode;
                    }
                    if (!string.IsNullOrEmpty(afterArg) && !string.IsNullOrEmpty(povCode))
                    {
                        povCode += afterArg;
                    }
                    if (!string.IsNullOrEmpty(povCode))
                    {
                        dico[idx] = povCode;
                    }
                }
            }
            var values = dico.Values;
            var result = string.Join(" ", values.Where(v => !string.IsNullOrWhiteSpace(v)));
            return result;
        }

        private static string GetPovCode(AbstractPovElement povElement)
        {
            string povCode = string.IsNullOrEmpty(povElement.Name) ? povElement.ToPovCode() : povElement.Name;
            return povCode;
        }

        private static string GetEnumPovCode(object propValue)
        {
            string povCode = propValue.ToString();
            if (povCode == "none")
            {
                return string.Empty;
            }

            return povCode;
        }
    }
}