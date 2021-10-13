using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace StringCalculator
{
    class StringCalculatorLogger
    {
        public static void Log()
        {
            var folder = @"C:\Users\aahernandez\source\repos\Katas\StringCalculator\Logs\";
            var filename = "SampleLog.txt";
            var path = folder + filename;
            string[] pruebalog = { GetCurrentDate() + " - probando esto a ver si funca" };

            File.AppendAllLines(path, pruebalog);
            Console.WriteLine("Logs Actualizados");
        }

        private static string GetCurrentDate()
        {
            return DateTime.Now.ToString("R");
        }
    }
}
