﻿using System;
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
                //var normalizedInput = SuppressBigNumbers(transformedInput);

                //return normalizedInput.Sum();
                return transformedInput.Sum();
            }

            if (!NotABigNumber(formattedInput)) return 0;
            return int.Parse(formattedInput);
        }

        private static void VerifyAllPositiveNumbers(IEnumerable<int> transformedInput)
        {
            string result = EMPTY_STRING;
            foreach (var possibleNegative in transformedInput)
            {
                if (possibleNegative < 0)
                    result += " " + possibleNegative;
            }
            if(!result.Equals(EMPTY_STRING))
                throw new Exception("negatives not allowed:" + result);
        }

        private static bool NotABigNumber(string input)
        {
            if (int.TryParse(input, out int bigNumber))
                if (bigNumber <= 1000) return true;
            
            return false;
        }

        private static string GetFormattedInput(string input, string findSeparator)
        {
            if (findSeparator.Equals(DEFAULT_SEPARATOR))
                return FormatInputIfNecessary(input, findSeparator);
            
            return FormatInputIfNecessary(input.Substring(3), findSeparator);
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

        private static IEnumerable<int> ConvertToIEnumerable(string input, string separator)
        {
            return input.Split(separator).Where(NotABigNumber).Select(int.Parse);
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
    }
}
