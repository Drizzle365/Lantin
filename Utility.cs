using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Lantin
{
    public static partial class Utility
    {
        public static string ReContent(string? s)
        {
            if (s is null)
                return "";
            var reg = MyRegex();
            var temp = reg.Replace(s, "");
            return temp.Replace("&nbsp;", " ");
        }
        public static string SubStr(string? s,int n)
        {
            if (s is null)
            {
                return "";
            }

            return n > s.Length ? s : string.Concat(s.AsSpan(0, n), " ···");
        }
        public static string EncodeMd5(string? s)
        {
            if (s == null) return "";
            var data = Encoding.UTF8.GetBytes(s);
            var result = MD5.HashData(data);
            var sb = new StringBuilder();
            foreach (var t in result)
            {
                sb.Append(t.ToString("x2"));
            }
            return sb.ToString();

        }

        [GeneratedRegex("<[^>]+>")]
        private static partial Regex MyRegex();
    }
}
