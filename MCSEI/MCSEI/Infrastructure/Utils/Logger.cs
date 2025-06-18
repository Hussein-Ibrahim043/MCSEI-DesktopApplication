using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_Project_SHA_V1._2.Services;

namespace Final_Project_SHA_V1._2.Infrastructure.Utils
{
    public static class Logger
    {
        private static readonly object _lock = new object();
        private static string _logFilePath = "D:\\app.log";

        public static void SetLogFilePath(string path)
        {
            _logFilePath = path;
        }

        public static void LogInfo(string message)
        {
            Log($"INFO: {SessionManager.Email} : {message}");
        }

        public static void Log(string message)
        {
            string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}";
            Console.WriteLine(logEntry);
            WriteToFile(logEntry);
        }

        public static void LogError(string message, Exception ex = null)
        {
            string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [ERROR] - {SessionManager.Email} - {message}";
            if (ex != null)
            {
                logEntry += Environment.NewLine + ex.ToString();
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(logEntry);
            Console.ResetColor();

            WriteToFile(logEntry);
        }

        private static void WriteToFile(string logEntry)
        {
            try
            {
                lock (_lock)
                {
                    File.AppendAllText(_logFilePath, logEntry + Environment.NewLine);
                }
            }
            catch
            {
                // Ignore file write errors
            }
        }
    }
}
