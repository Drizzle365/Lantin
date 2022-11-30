using System.Text.RegularExpressions;

namespace Lantin
{
    public static class Utility
    {
        public static string ReContent(string? s)
        {
            if (s is null)
                return "";
            Regex reg = new("<[^>]+>");
            var temp = reg.Replace(s, "");
            return temp.Replace("&nbsp;", " ");
        }
    }
}
