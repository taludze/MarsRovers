using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace MarsRover.Common
{
    public static class EnumExtentions
    {
        public static string GetDescription(this Enum enumValue)
        {
            return !(enumValue.GetType()
                   .GetField(enumValue.ToString())
                   .GetCustomAttributes(typeof(DescriptionAttribute), false)
                   .SingleOrDefault() is DescriptionAttribute attribute) ? enumValue.ToString() : attribute.Description;
        }
    }
}
