using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public static class StringCalculator
    {
        private const string DEFAULT_SEPARATOR = ",";
        private const string NEW_LINE_TAG = "\n";
        private const string CHANGE_SEPARATOR_TAG = "//";
        private const string EXC_NEGATIVE_NOT_ALLOWED = @"negatives not allowed:{0}";

        public static int ExecuteV1(string input)
        {
            if (string.IsNullOrEmpty(input)) return 0;
            var numbers = Transform(input);
            var validNumbers = GetValidNumbers(numbers);
            return validNumbers.Sum();
        }

        public static int ExecuteV2(string input)
        {
            if (string.IsNullOrEmpty(input)) return 0;
            var numbers = Transform(input);
            var validNumbers = GetValidNumbers(numbers);
            return validNumbers.Sum();
        }

        private static IEnumerable<int> Transform(string input)
        {
            var separator = GetSeparator(input);
            var formattedInput = GetFormattedInput(input, separator);
            if (formattedInput.StartsWith(separator))
                formattedInput = formattedInput.Substring(1);
            return GetNumbers(formattedInput, separator);
        }

        private static string GetSeparator(string input)
        {
            if (input.StartsWith(CHANGE_SEPARATOR_TAG))
                return input[2].ToString();
            return DEFAULT_SEPARATOR;
        }
        
        private static string GetFormattedInput(string input, string separator)
        {
            if (separator.Equals(DEFAULT_SEPARATOR))
                return ChangeNewLinesToSeparator(input, separator);

            return ChangeNewLinesToSeparator(input.Substring(3), separator);
        }

        private static string ChangeNewLinesToSeparator(string input, string separator)
        {
            return input.Replace(NEW_LINE_TAG, separator);
        }

        private static IEnumerable<int> GetNumbers(string input, string separator)
        {
            return input.Split(separator).Select(int.Parse);
        }

        private static bool IsSmallNumber(int number)
        {
            return number <= 1000;
        }

        private static IEnumerable<int> GetValidNumbers(IEnumerable<int> numbers)
        {
            var negativeList = numbers.Where(IsNegativeNumber);
            if (negativeList.Any())
                throw new ArithmeticException(GetNegativeMessageException(negativeList));
            return numbers.Where(IsSmallNumber);
        }

        private static bool IsNegativeNumber(int number)
        {
            return number < 0;
        }

        private static string GetNegativeMessageException(IEnumerable<int> negativeNumbers)
        {
            var result = string.Empty;
            foreach (var negative in negativeNumbers)
                result += " " + negative;
            return string.Format(EXC_NEGATIVE_NOT_ALLOWED, result);
        }
    }
}
