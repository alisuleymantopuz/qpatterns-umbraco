using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qPatterns.Core.Extensions
{
    public static class IntegerExtensionMethods
    {
        public static double CalculateDeviation(this IEnumerable<int> values)
        {
            double deviation = 0;

            var numbers = values as int[] ?? values.ToArray();
            
            var numbersCount = numbers.Count();

            if (numbersCount <= 1) return deviation;

            var avg = numbers.Average();

            var sum = numbers.Sum(n => (n - avg) * (n - avg));
                
            deviation = Math.Sqrt(sum / numbersCount);

            return deviation;
        }

        public static long ToInt16(this string value)
        {
            Int16 result = 0;

            if (!string.IsNullOrEmpty(value))
                Int16.TryParse(value, out result);

            return result;
        }

        public static long ToInt32(this string value)
        {
            Int32 result = 0;

            if (!string.IsNullOrEmpty(value))
                Int32.TryParse(value, out result);

            return result;
        }

        public static long ToInt64(this string value)
        {
            Int64 result = 0;

            if (!string.IsNullOrEmpty(value))
                Int64.TryParse(value, out result);

            return result;
        }
    }
}
