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

            return ProcessedInput(input);
        }

        private static int ProcessedInput(string input)
        {

            if (input.Contains(NEW_LINE_TAG))
            {
                input = ChangeNewLinesToCommas(input);
            }

            if (input.Contains(SEPARATOR))
            {
                var transformedInput = Transform(input);
                return transformedInput.Sum();
            }

            return int.Parse(input);
        }

        private static string ChangeNewLinesToCommas(string input)
        {
            return input.Replace(NEW_LINE_TAG, SEPARATOR);
        }

        private static IEnumerable<int> Transform(string input)
        {
            return input.Split(SEPARATOR).Select(int.Parse);
        }
    }
}
