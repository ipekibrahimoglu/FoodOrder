using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Helpers
{
    public static class ValidationHelpers
    {
        public static bool HasValidDecimalPrecision(decimal value, int maxTotalDigits, int maxFractionalDigits)
        {
            var parts = value.ToString(System.Globalization.CultureInfo.InvariantCulture).Split('.');
            var integerDigits = parts[0].TrimStart('-').Length;
            var fractionalDigits = parts.Length > 1 ? parts[1].Length : 0;
            return (integerDigits + fractionalDigits) <= maxTotalDigits && fractionalDigits <= maxFractionalDigits;
        }
    }
}
