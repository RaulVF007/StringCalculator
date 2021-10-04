using System;
using System.Collections;
using System.Collections.Generic;

namespace StringCalculator
{
    public static class StringCalculator
    {
        private const string SEPARATOR = ",";

        public static int Add(string input)
        {
            if (string.IsNullOrEmpty(input))
                return 0;
            if (input.Contains(SEPARATOR))
            {
                var transformedInput = Transform(input);
                return SumOfAllNumbers(transformedInput);
            }

            return int.Parse(input);
        }

        private static int SumOfAllNumbers(IEnumerable<int> transformedInput)
        {
            var result = 0;
            foreach (var number in transformedInput) {
                result += number;
            }
            return result;
        }

        private static IEnumerable<int> Transform(string input)
        {
            var splittedInput = input.Split(SEPARATOR);
            var result = new List<int>();

            foreach (var number in splittedInput) {
                result.Add(int.Parse(number));
            }

            return result.ToArray();
        }
    }
}
