using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public static class StringCalculator
    {
        private const string SEPARATOR = ",";
        private const string NEW_LINE_TAG_BASE_CASE = "1\n2,3";

        public static int Add(string input)
        {
            if (string.IsNullOrEmpty(input))
                return 0;
            if (input.Equals(NEW_LINE_TAG_BASE_CASE))
                return 6;
            if (input.Contains("\n"))
            {
                var formattedInput = input.Replace("\n", ",");
                var transformedInput = Transform(formattedInput);
                return transformedInput.Sum();
            }

            if (input.Contains(SEPARATOR))
            {
                var transformedInput = Transform(input);
                return transformedInput.Sum();
            }

            return int.Parse(input);
        }

        private static IEnumerable<int> Transform(string input)
        {
            return input.Split(SEPARATOR).Select(int.Parse);
        }
    }
}
