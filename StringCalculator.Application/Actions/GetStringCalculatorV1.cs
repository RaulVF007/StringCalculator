using System;
using StringCalculator.Application.Model;

namespace StringCalculator.Application.Actions
{
    public class GetStringCalculatorV1
    {

        private static readonly string APP_TITLE = "String Calculator";
        private ILogger logger;
        public GetStringCalculatorV1(ILogger logger)
        {
            this.logger = logger;
        }

        public string Execute(string input)
        {
            var consoleInput = input;
            try
            {
                var result = CalculateStringInput(consoleInput);
                return result;
            }
            catch (ArithmeticException e)
            {
                logger.AddErrorEntry(consoleInput, e.Message);
                throw e;
            }
            catch(Exception e)
            {
                logger.AddErrorEntry(consoleInput, "ERROR: Incorrect Format");
                throw e;
            }
        }

        private string CalculateStringInput(string consoleInput)
        {
            var calculatedString = StringCalculator.ExecuteV1(consoleInput);
            this.logger.AddEntry(consoleInput, calculatedString);
            return calculatedString.ToString();
        }
    }
}
