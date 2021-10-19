using System;
using System.IO;
using StringCalculator.Application.Model;

namespace StringCalculator.Infrastructure
{
    public class StringCalculatorLogger : ILogger
    {
        public static readonly string LOG_FOLDER = "../Logs/";
        public static readonly string LOG_FILE = "Log.txt";
        public static readonly string ERROR_FILE = "Errors.txt";

        public void AddEntry(string consoleInput, int calculatedString)
        {
            var folder = GetLogFolder();
            var filename = LOG_FILE;
            var path = folder + filename;
            WriteToLog(GetLogMsg(consoleInput, calculatedString.ToString()), path);
        }

        public void AddErrorEntry(string consoleInput, string message)
        {
            var folder = LOG_FOLDER;
            var filename = ERROR_FILE;
            var path = folder + filename;
            WriteToLog(GetLogMsg(consoleInput, message), path);
        }

        private static string GetLogFolder()
        {
            if (!Directory.Exists(LOG_FOLDER))
            {
                Directory.CreateDirectory(LOG_FOLDER);
            }

            return LOG_FOLDER;
        }

        private static void WriteToLog(string logMessage, string path)
        {
            string[] pruebalog = { GetCurrentDate() + " - " + logMessage };
            File.AppendAllLines(path, pruebalog);
        }

        private static string GetLogMsg(string consoleInput, string calculatedString)
        {
            return "Process Finished: '" + consoleInput + "', result: " + calculatedString;
        }

        private static string GetCurrentDate()
        {
            return DateTime.UtcNow.ToString("g");
        }
    }
}
