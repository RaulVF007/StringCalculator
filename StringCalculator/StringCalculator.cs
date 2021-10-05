using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public static class StringCalculator
    {
        private static string SEPARATOR = ",";
        private const string NEW_LINE_TAG = "\n";

        public static int Add(string input)
        {
            if (string.IsNullOrEmpty(input))
                return 0;

            return AdditionOfNumbers(input);
        }

        private static int AdditionOfNumbers(string input)
        {
            var findSeparator = FindSeparator(input);
            var formattedInput = GetFormattedInput(input, findSeparator);

            if (formattedInput.Contains(findSeparator))
            {
                var transformedInput = ConvertToIEnumerable(formattedInput, findSeparator);
                return transformedInput.Sum();
            }

            return int.Parse(formattedInput);
        }

        private static string GetFormattedInput(string input, string findSeparator)
        {
            if (findSeparator.Equals(","))
                return FormatInputIfNecessary(input, findSeparator);
            
            return FormatInputIfNecessary(input.Substring(3), findSeparator);
        }

        private static string FindSeparator(string input)
        {
            if (input.StartsWith("//"))
                return GetSeparator(input);
            return ",";
        }

        private static string GetSeparator(string input)
        {
            return input[2].ToString();
        }

        private static IEnumerable<int> ConvertToIEnumerable(string input, string separator)
        {
            return input.Split(separator).Select(int.Parse);
        }

        private static string FormatInputIfNecessary(string input, string separator)
        {
            if (input.StartsWith("\n"))
                return ChangeNewLinesToSeparator(input.Substring(1), separator);
            return ChangeNewLinesToSeparator(input, separator); ;
        }

        private static string ChangeNewLinesToSeparator(string input, string separator)
        {
            return input.Replace(NEW_LINE_TAG, separator);
        }
    }
}
