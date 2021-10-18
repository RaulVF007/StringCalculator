using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using StringCalculator.Application.Model;

namespace StringCalculator.Application.Actions
{
    public class GetStringCalculator
    {

        private static readonly string APP_TITLE = "String Calculator";
        private Logger logger;
        public GetStringCalculator(Logger logger)
        {
            this.logger = logger;
        }

        public void Execute()
        {
            GiveWelcomeToUser();
            while (true)
            {
                var consoleInput = Console.ReadLine();
                try
                {
                    CalculateStringInput(consoleInput);
                    Console.WriteLine("Task finished successfully: Logs Updated\n");
                }
                catch (ArithmeticException e)
                {
                    logger.AddErrorEntry(consoleInput, e.Message);
                    Console.WriteLine("Task failed: See Errors.txt for more info.\n");
                }
                catch
                {
                    logger.AddErrorEntry(consoleInput, "ERROR: Incorrect Format");
                    Console.WriteLine("Task failed: See Errors.txt for more info.\n");
                }
                DisplayInstructions();
            }
        }

        private void CalculateStringInput(string consoleInput)
        {
            if (consoleInput.Equals("q"))
                Environment.Exit(0);
            var calculatedString = StringCalculator.Execute(consoleInput);
            Console.WriteLine(calculatedString);
            this.logger.AddEntry(consoleInput, calculatedString);
        }

        private static void GiveWelcomeToUser()
        {
            Console.WriteLine(APP_TITLE);
            DisplayInstructions();
        }

        private static void DisplayInstructions()
        {
            Console.WriteLine("Please, type the input to process");
        }
    }
}
