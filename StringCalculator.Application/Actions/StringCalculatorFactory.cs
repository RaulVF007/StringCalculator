
using StringCalculator.Application.Model;

namespace StringCalculator.Application.Actions
{
    public class StringCalculatorFactory
    {
        public static GetStringCalculator Create(string version, ILogger logger)
        {
            switch (version)
            {
                case "1":
                    return CreateStringCalculatorV1(logger);
                default:
                    return CreateStringCalculatorV2(logger);
            }
        }

        public static GetStringCalculatorV1 CreateStringCalculatorV1(ILogger logger)
        {
            return new GetStringCalculatorV1(logger);
        }
        public static GetStringCalculatorV2 CreateStringCalculatorV2(ILogger logger)
        {
            return new GetStringCalculatorV2(logger);
        }
    }

    public interface GetStringCalculator
    {
        public string Execute(string input);
    }
}
