using StringCalculator.Infrastructure;
using StringCalculator.Application.Actions;

namespace StringCalculator.Console
{
    class Program
    {
        public static void Main(string[] args)
        {
            var logger = new StringCalculatorLogger();
            new GetStringCalculator(logger).Execute();
        }
    }
}
