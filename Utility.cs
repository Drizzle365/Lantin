using System.Security.Cryptography;
using System.Text;
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
        public static string SubStr(string? s,int n)
        {
            if (s is null)
            {
                return "";
            }
            if (n > s.Length)
                return s;
            else
                return s.Substring(0, n) + " ···";
        }
        public static string EncodeMD5(string? s)
        {
            byte[] data = Encoding.UTF8.GetBytes(s);
            byte[] result = MD5.HashData(data);
            var sb = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                sb.Append(result[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
