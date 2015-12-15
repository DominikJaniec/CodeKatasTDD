using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KataRomanNumerals
{
    public static class Romaner
    {
        public static string ToRoman(int value)
        {
            var romanResult = new StringBuilder();

            var currentValue = value;
            while (currentValue > 0)
            {
                var key = FindArabicKey(currentValue);
                if (key.HasValue == false)
                    break;

                var arabicKey = key.GetValueOrDefault();
                var romanNumber = _arabicToRomanMap[arabicKey];
                romanResult.Append(romanNumber);

                currentValue -= arabicKey;
            }

            return romanResult.ToString();
        }

        private static int? FindArabicKey(int currentValue)
        {
            return _availableArabicKeysDesc
                .FirstOrDefault(key => key <= currentValue);
        }

        private static readonly IReadOnlyDictionary<int, string> _arabicToRomanMap;
        private static readonly IReadOnlyList<int?> _availableArabicKeysDesc;

        static Romaner()
        {
            _arabicToRomanMap = new Dictionary<int, string>
            {
                { 1, "I" },
                { 4, "IV" },
                { 5, "V" }
            };

            _availableArabicKeysDesc = _arabicToRomanMap.Keys
                .Cast<int?>()
                .OrderByDescending(key => key)
                .ToList()
                .AsReadOnly();
        }
    }
}
