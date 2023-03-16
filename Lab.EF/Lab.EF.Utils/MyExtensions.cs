using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab.EF.Utils
{
    public static class MyExtensions
    {
        public static bool ContainLetters(this string str)
        {
            string regex = "^[0-9]+$";

            return Regex.IsMatch(str, regex);
        }
    }
}
