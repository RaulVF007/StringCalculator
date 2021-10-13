using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace StringCalculator
{
    class StringCalculatorLogger
    {
        public static void Log(string consoleInput, int calculatedString)
        {
            var folder = @"C:\Users\aahernandez\source\repos\Katas\StringCalculator\Logs\";
            var filename = "Log.txt";
            var path = folder + filename;
            string[] pruebalog = { GetCurrentDate() + " - " + GetLogMsg(consoleInput, calculatedString) };

            File.AppendAllLines(path, pruebalog);
            Console.WriteLine("Logs Actualizados");
        }

        private static string GetLogMsg(string consoleInput, int calculatedString)
        {
            return "Operación Realizada: " + consoleInput + ", resultado: " + calculatedString;
        }

        private static string GetCurrentDate()
        {
            return DateTime.Now.ToString("R");
        }
    }
}
