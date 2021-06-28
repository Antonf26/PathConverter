using System;
using System.Text.RegularExpressions;

namespace JsonPathConvert
{
    public static class PathConverter
    {
        public static string Convert(string input)
        {
            var replace = Regex.Replace(input, @"\.(\w+ \w+)($|\[|\.| )", ".['$1']$2");
            return replace;
        }
    }
}
