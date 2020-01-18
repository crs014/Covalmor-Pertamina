using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovalmorPertamina.Common.Statics
{
    public static class StringService
    {

        public static string GenerateGuidString()
        {
            Guid g = Guid.NewGuid();
            string GuidString = Convert.ToBase64String(g.ToByteArray());
            GuidString = GuidString.Replace("=", "");
            GuidString = GuidString.Replace("+", "");
            return GuidString;
        }

        public static string AddSpacesToBeforeCapital(string text)
        {
            text = string.Concat(text.Select(x => Char.IsUpper(x) ? " " + x : x.ToString())).TrimStart(' ');
            return text;
        }
    }
}
