using FluentAssertions;
using NUnit.Framework;

namespace StringCalculator.Test {
    public class StringCalculatorShould {
        [SetUp]
        public void Setup() {
        }

        [Test]
        public void Return_0_when_string_is_empty() {
            //Given
            string input = "";

            //When
            int result = StringCalculator.Add(input);

            //Then
            result.Should().Be(0);
            Assert.Pass();
        }

        [Test]
        public void Return_1_when_input_is_1() {
            const string input = "1";

            var result = StringCalculator.Add(input);

            result.Should().Be(1);
        }

        [Test]
        public void Return_a_number_when_input_is_that_number()
        {
            const string input = "2";

            var result = StringCalculator.Add(input);

            result.Should().Be(2);
        }

        [Test]
        public void Return_3_when_input_is_1_and_2() {
            const string input = "1,2";

            var result = StringCalculator.Add(input);
            
            result.Should().Be(3);
        }

        [Test]
        public void return_addition_when_input_is_two_numbers()
        {
            var input = "4,2";

            var result = StringCalculator.Add(input);

            result.Should().Be(6);
        }
        
        [Test]
        public void return_addition_when_input_is_more_than_two_numbers()
        {
            var input = "4,2,1";

            var result = StringCalculator.Add(input);

            result.Should().Be(7);
        }

        [Test]
        public void return_6_when_input_is_1_2_and_3_and_has_new_line_tag_and_commas()
        {
            var input = "1\n2,3";

            var result = StringCalculator.Add(input);

            result.Should().Be(6);
        }

        [Test]
        public void return_addition_when_input_is_two_numbers_and_has_new_line_tag()
        {
            var input = "1\n2";

            var result = StringCalculator.Add(input);

            result.Should().Be(3);
        }


        
    }
}