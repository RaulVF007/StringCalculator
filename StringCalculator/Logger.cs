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
            string[] pruebalog = {"probando esto a ver si funca"};

            File.WriteAllLines(path, pruebalog);
            Console.WriteLine("Logs Actualizados");
        }
    }
}
