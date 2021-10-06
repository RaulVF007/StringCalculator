using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public static class StringCalculator
    {
        private const string DEFAULT_SEPARATOR = ",";
        private const string NEW_LINE_TAG = "\n";
        private const string CHANGE_SEPARATOR_TAG = "//";
        private const string EMPTY_STRING = "";

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
                VerifyAllPositiveNumbers(transformedInput);
                return transformedInput.Sum();
            }

            if (!IsSmallNumber(formattedInput)) return 0;
            return int.Parse(formattedInput);
        }

        private static string FindSeparator(string input)
        {
            if (input.StartsWith(CHANGE_SEPARATOR_TAG))
                return GetSeparator(input);
            return DEFAULT_SEPARATOR;
        }
        private static string GetSeparator(string input)
        {
            return input[2].ToString();
        }

        private static string GetFormattedInput(string input, string findSeparator)
        {
            if (findSeparator.Equals(DEFAULT_SEPARATOR))
                return FormatInputIfNecessary(input, findSeparator);

            return FormatInputIfNecessary(input.Substring(3), findSeparator);
        }

        private static string FormatInputIfNecessary(string input, string separator)
        {
            if (input.StartsWith(NEW_LINE_TAG))
                return ChangeNewLinesToSeparator(input.Substring(1), separator);
            return ChangeNewLinesToSeparator(input, separator); ;
        }

        private static string ChangeNewLinesToSeparator(string input, string separator)
        {
            return input.Replace(NEW_LINE_TAG, separator);
        }

        private static IEnumerable<int> ConvertToIEnumerable(string input, string separator)
        {
            return input.Split(separator).Where(IsSmallNumber).Select(int.Parse);
        }

        private static bool IsSmallNumber(string input)
        {
            if (int.TryParse(input, out int bigNumber))
                if (bigNumber <= 1000) return true;

            return false;
        }

        private static void VerifyAllPositiveNumbers(IEnumerable<int> transformedInput)
        {
            var negativeList = transformedInput.Where(IsNegativeNumber).ToList();
            if (negativeList.ToList().Count>0)
                throw new Exception(NegativeValuesAsString(negativeList));
        }
        private static bool IsNegativeNumber(int input)
        {
            return input < 0;
        }

        private static string NegativeValuesAsString(IEnumerable<int> input)
        {
            string result = EMPTY_STRING;
            foreach (var negative in input)
                result += " " + negative;
            return "negatives not allowed:" + result;
        }
    }
}
