using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public static class StringCalculator
    {
        private const string SEPARATOR = ",";
        private const string NEW_LINE_TAG = "\n";

        public static int Add(string input)
        {
            if (string.IsNullOrEmpty(input))
                return 0;

            return AdditionOfNumbers(input);
        }

        private static int AdditionOfNumbers(string input)
        {
            var formattedInput = FormatInputIfNecessary(input);

            if (formattedInput.Contains(SEPARATOR))
            {
                var transformedInput = ConvertToIEnumerable(formattedInput);
                return transformedInput.Sum();
            }

            return int.Parse(formattedInput);
        }

        private static IEnumerable<int> ConvertToIEnumerable(string input)
        {
            return input.Split(SEPARATOR).Select(int.Parse);
        }

        private static string FormatInputIfNecessary(string input)
        {
            if (input.Contains(NEW_LINE_TAG))
            {
                input = ChangeNewLinesToCommas(input);
            }
            return input;
        }

        private static string ChangeNewLinesToCommas(string input)
        {
            return input.Replace(NEW_LINE_TAG, SEPARATOR);
        }
    }
}
