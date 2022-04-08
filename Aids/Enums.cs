using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TeamUP.Aids
{
    public static class Enums
    {
        public static string Description(this Enum v)
        {
            var i = v.GetType().GetField(v.ToString());
            var a = i?.GetCustomAttribute(typeof(DescriptionAttribute)) as DescriptionAttribute;
            return a?.Description ?? v.ToString();
        }
    }
}
