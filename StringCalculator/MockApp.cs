using System;

namespace StringCalculator
{
    class MockApp
    {
        public static void Main(string[] args)
        {
            GiveWelcomeToUser();
                try
                {
                    CalculateStringInput();
                    DisplayInstructions();
                }
                catch (Exception e)
                {
                    DisplayExceptionMessageInConsole(e);
                    DisplayInstructions();
                }
            
        }

        private static void DisplayInstructions()
        {
            Console.WriteLine("Inserte una sucesión de caracteres o 'q' para salir");
        }

        private static void GiveWelcomeToUser()
        {
            Console.WriteLine("Calculadora de Strings");
            DisplayInstructions();
        }

        private static void CalculateStringInput()
        {
            var consoleInput = Console.ReadLine();
            if (consoleInput.Equals("q"))
                Environment.Exit(0);
            var calculatedString = StringCalculator.Execute(consoleInput);
            Console.WriteLine(calculatedString);
            StringCalculatorLogger.Log(consoleInput, calculatedString);
        }

        private static void DisplayExceptionMessageInConsole(Exception e)
        {
            if (e is ArithmeticException)
            {
                Console.WriteLine("ERROR: " + e.Message);
            }
            else
            {
                Console.WriteLine("ERROR: Formato Incorrecto");
            }
        }
    }
}
