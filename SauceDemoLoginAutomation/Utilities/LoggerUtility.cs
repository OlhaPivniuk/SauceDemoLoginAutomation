using System.Text;

namespace SauceDemoLoginAutomation.Utilities
{
    public static class LoggerUtility
    {
        private static readonly string logFilePath = Path
        .Combine(AppDomain.CurrentDomain.BaseDirectory, "test_logs.txt");
        static LoggerUtility()
        {
            if (File.Exists(logFilePath))
            {
                File.Delete(logFilePath);
            }
            File.Create(logFilePath).Dispose();
        }
        public static void Log(string message)
        {
            int threadId = System.Threading.Thread.CurrentThread.ManagedThreadId;
            string logMessage = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [Thread {threadId}] {message}";

            Console.WriteLine(logMessage);

            using (var streamWriter = new StreamWriter(logFilePath, true, Encoding.UTF8))
            {
                streamWriter.WriteLine(logMessage);
            }
        }

    }
}