using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection.PortableExecutable;
using System.Text;

namespace StringCalculator
{
    class MockApp
    {
        public static void Main(string[] args)
        {
            GiveWelcomeToUser();
            while (true)
            {
                try
                {
                    CalculateStringInput();
                    StringCalculatorLogger.Log();
                    DisplayInstructions();
                }
                catch (Exception e)
                {
                    DisplayExceptionMessageInConsole(e);
                    StringCalculatorLogger.Log();
                    DisplayInstructions();
                }
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
            Console.WriteLine(StringCalculator.Execute(consoleInput));
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
