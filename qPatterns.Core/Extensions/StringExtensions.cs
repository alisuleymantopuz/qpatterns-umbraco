using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace qPatterns.Core.Extensions
{
    public static class StringExtensions
    {
        public static bool IsValidEmail(this string value)
        {
            return new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,6}$").IsMatch(value);
        }

        public static bool IsValidUrl(this string value)
        {
            const string strRegex = "^(https?://)"
                                    + "?(([0-9a-z_!~*'().&=+$%-]+: )?[0-9a-z_!~*'().&=+$%-]+@)?"
                                    + @"(([0-9]{1,3}\.){3}[0-9]{1,3}"
                                    + "|"
                                    + @"([0-9a-z_!~*'()-]+\.)*"
                                    + @"([0-9a-z][0-9a-z-]{0,61})?[0-9a-z]"
                                    + @"(\.[a-z]{2,6})?)"
                                    + "(:[0-9]{1,5})?"
                                    + "((/?)|"
                                    + "(/[0-9a-z_!~*'().;?:@&=+$,%#-]+)+/?)$";

            return new Regex(strRegex).IsMatch(value);
        }

        public static string Reverse(this string value)
        {
            char[] chars = value.ToCharArray();

            Array.Reverse(chars);

            return new String(chars);
        }


        public static string LessFormat(this string value, int count, string endings)
        {
            if (endings == null)
                return string.Empty;

            if (endings != null && count < endings.Length)
                throw new Exception("Failed to reduce to less then endings length.");

            int sLength = value.Length;

            int len = sLength;
            
            len += endings.Length;

            if (count > sLength)
                return value; 

            value = value.Substring(0, sLength - len + count);
          
            value += endings;

            return value;
        }

        public static string RemoveSpaces(this string s)
        {
            return s.Replace(" ", "");
        }

        public static bool IsNumber(this string s, bool floatpoint)
        {
            int i;
            double d;
            string withoutWhiteSpace = s.RemoveSpaces();
            if (floatpoint)
                return double.TryParse(withoutWhiteSpace, NumberStyles.Any,
                    Thread.CurrentThread.CurrentUICulture, out d);
            
            return int.TryParse(withoutWhiteSpace, out i);
        }

        public static bool IsNumberOnly(this string s, bool floatpoint)
        {
            s = s.Trim();
            return s.Length != 0 && s.Where(c => !char.IsDigit(c)).All(c => floatpoint && (c == '.' || c == ','));
        }

        public static string RemoveDiacritics(this string s)
        {
            string stFormD = s.Normalize(NormalizationForm.FormD);

            var sb = new StringBuilder();

            foreach (char t in stFormD)
            {
                var uc = CharUnicodeInfo.GetUnicodeCategory(t);
                if (uc != UnicodeCategory.NonSpacingMark) 
                    sb.Append(t); 
            }

            return (sb.ToString().Normalize(NormalizationForm.FormC));
        }

        public static DateTime ToDate(this string input, bool throwExceptionIfFailed = false)
        {
            DateTime result;
            var valid = DateTime.TryParse(input, out result);
            if (!valid)
                if (throwExceptionIfFailed)
                    throw new FormatException(string.Format("'{0}' cannot be converted as DateTime", input));

            return result;
        }

        public static int ToInt(this string input, bool throwExceptionIfFailed = false)
        {
            int result;
            var valid = int.TryParse(input, out result);
            if (!valid)
                if (throwExceptionIfFailed)
                    throw new FormatException(string.Format("'{0}' cannot be converted as int", input));

            return result;
        }

        public static double ToDouble(this string input, bool throwExceptionIfFailed = false)
        {
            double result;
            var valid = double.TryParse(input, NumberStyles.AllowDecimalPoint,
              new NumberFormatInfo { NumberDecimalSeparator = "." }, out result);
            if (!valid)
                if (throwExceptionIfFailed)
                    throw new FormatException(string.Format("'{0}' cannot be converted as double", input));
           
            return result;
        }

        public static string ToSentence(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;

            if (Regex.Match(input, "[0-9A-Z]+$").Success)
                return input;
            
            var result = Regex.Replace(input, "(\\B[A-Z])", " $1");

            return result;
        }
    }
}
