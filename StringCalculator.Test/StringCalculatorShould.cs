using FluentAssertions;
using NUnit.Framework;

namespace StringCalculator.Test
{
    public class StringCalculatorShould
    {

        [Test]
        public void return_0_when_string_is_empty()
        {
            // Given
            const string input = "";
            // When
            var result = StringCalculator.Add(input);
            // Then
            result.Should().Be(0);
        }

        [TestCase("1",1)]
        [TestCase("2", 2)]
        [TestCase("3", 3)]
        public void return_a_number_when_input_is_that_number(string input, int expected)
        {
            var result = StringCalculator.Add(input);

            result.Should().Be(expected);
        }
        
        [TestCase("4,2", 6)]
        [TestCase("2,2", 4)]
        [TestCase("3,2", 5)]
        public void return_addition_when_input_is_two_numbers(string input, int expected)
        {
            var result = StringCalculator.Add(input);

            result.Should().Be(expected);
        }

        [TestCase("4,2,1", 7)]
        [TestCase("2,2,1", 5)]
        [TestCase("3,2,4", 9)]
        public void return_addition_when_input_is_more_than_two_numbers(string input, int expected)
        {
            var result = StringCalculator.Add(input);

            result.Should().Be(expected);
        }

        [TestCase("1\n2,3\n4,5", 15)]
        [TestCase("1\n2", 3)]
        [TestCase("1\n2,3", 6)]
        public void return_addition_when_input_has_both_delimiters(string input, int expected)
        {

            var result = StringCalculator.Add(input);

            result.Should().Be(expected);
        }

        [Test]
        public void return_addition_with_any_delimeter_and_new_lines()
        {
            var input = "//;\n1;2";

            var result = StringCalculator.Add(input);

            result.Should().Be(3);

        }
    }
}