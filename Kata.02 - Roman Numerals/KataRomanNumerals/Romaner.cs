using System;
using System.Collections.Generic;
using System.Linq;

namespace KataRomanNumerals
{
    public static class Romaner
    {
        public static string ToRoman(int value)
        {
            var arabicKeys = GetKeySequence(value);
            var correctKeys = ApplyRepetitionLimit(arabicKeys);
            var romanNumbers = TranslateToRoman(correctKeys);

            return string.Join(string.Empty, romanNumbers);
        }

        private static IEnumerable<int> GetKeySequence(int arabicValue)
        {
            var currentValue = arabicValue;
            while (currentValue > 0)
            {
                var currentKey = _arabicToRomanMap.Keys
                    .OrderByDescending(key => key)
                    .First(key => key <= currentValue);

                yield return currentKey;
                currentValue -= currentKey;
            }
        }

        private static IEnumerable<int> ApplyRepetitionLimit(IEnumerable<int> keys)
        {
            var lastKey = Int32.MinValue;
            var sameKeyBuffor = new List<int>();

            foreach (var currentKey in keys)
            {
                if (currentKey != lastKey)
                {
                    foreach (var key in sameKeyBuffor)
                    {
                        yield return key;
                    }

                    lastKey = currentKey;
                    sameKeyBuffor = new List<int>();
                }

                sameKeyBuffor.Add(currentKey);

                if (sameKeyBuffor.Count == 4)
                {
                    var biggerKey = _arabicToRomanMap.Keys
                        .OrderBy(key => key)
                        .Cast<int?>()
                        .FirstOrDefault(key => key > currentKey);

                    if (biggerKey.HasValue)
                    {
                        sameKeyBuffor = new List<int>();

                        yield return currentKey;
                        yield return biggerKey.Value;
                    }
                }
            }

            foreach (var key in sameKeyBuffor)
            {
                yield return key;
            }
        }

        private static IEnumerable<string> TranslateToRoman(IEnumerable<int> arabicKeys)
        {
            return arabicKeys
                .Select(key => _arabicToRomanMap[key]);
        }

        private static readonly IReadOnlyDictionary<int, string> _arabicToRomanMap
            = new Dictionary<int, string>
            {
                { 1, "I" },
                { 5, "V" },
                { 10, "X" },
                { 50, "L" },
                { 100, "C" },
                { 500, "D" },
                { 1000, "M" },
            };
    }
}
