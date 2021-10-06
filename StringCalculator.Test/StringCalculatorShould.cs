using System;
using FluentAssertions;
using NUnit.Framework;

namespace StringCalculator.Test
{
    public class StringCalculatorShould
    {

        [Test]
        public void return_zero_when_string_is_empty()
        {
            // Given
            const string input = "";
            // When
            var result = StringCalculator.Execute(input);
            // Then
            result.Should().Be(0);
        }

        [TestCase("1",1)]
        [TestCase("2", 2)]
        [TestCase("3", 3)]
        public void return_a_number_when_input_is_that_number(string input, int expected)
        {
            var result = StringCalculator.Execute(input);

            result.Should().Be(expected);
        }
        
        [TestCase("4,2", 6)]
        [TestCase("2,2", 4)]
        [TestCase("3,2", 5)]
        public void return_addition_when_input_is_two_numbers(string input, int expected)
        {
            var result = StringCalculator.Execute(input);

            result.Should().Be(expected);
        }

        [TestCase("4,2,1", 7)]
        [TestCase("2,2,1", 5)]
        [TestCase("3,2,4", 9)]
        public void return_addition_when_input_is_more_than_two_numbers(string input, int expected)
        {
            var result = StringCalculator.Execute(input);

            result.Should().Be(expected);
        }

        [TestCase("1\n2,3\n4,5", 15)]
        [TestCase("1\n2", 3)]
        [TestCase("1\n2,3", 6)]
        public void return_addition_when_input_has_both_delimiters(string input, int expected)
        {

            var result = StringCalculator.Execute(input);

            result.Should().Be(expected);
        }

        [TestCase("//;\n1;2", 3)]
        [TestCase("//;1;2", 3)]
        [TestCase("//:1:2:3", 6)]
        [TestCase("//:1:2\n3", 6)]
        [TestCase("//:\n1:2\n3", 6)]
        public void return_addition_with_any_delimiter_and_new_lines(string input, int expected)
        {

            var result = StringCalculator.Execute(input);

            result.Should().Be(expected);

        }

        [TestCase("-1", "negatives not allowed: -1")]
        [TestCase("1,4,-1", "negatives not allowed: -1")]
        [TestCase("1,4,-1,-2", "negatives not allowed: -1 -2")]
        [TestCase("//;1;4;-1;-2", "negatives not allowed: -1 -2")]
        [TestCase("//:\n1:4\n-1:-2:-3", "negatives not allowed: -1 -2 -3")]
        public void return_exception_if_there_is_at_least_one_negative_number(string input, string expected)
        {
            Action act = () => StringCalculator.Execute(input);

            act.Should().Throw<Exception>().WithMessage(expected);
        }
                
        [TestCase("1001", 0)]
        [TestCase("1002", 0)]
        [TestCase("2000", 0)]
        [TestCase("1,2000", 1)]
        [TestCase("2000,5", 5)]
        [TestCase("//:2000:5", 5)]
        [TestCase("//:2000:5:6", 11)]
        public void return_addition_when_there_is_at_least_a_big_number(string input, int expected)
        {
            var result = StringCalculator.Execute(input);

            result.Should().Be(expected);
        }
    }
}