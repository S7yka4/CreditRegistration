namespace CreditRegistrationService.Logs
{
    public class FileLogger : ILogger
    {
        bool _isDevelop;
        string _fileName;
        private static object _locker = new object();

        public FileLogger(string fileName, bool isDevelop)
        {
            _fileName = $"{Directory.GetCurrentDirectory()}{Path.DirectorySeparatorChar}{fileName}";
            _isDevelop = isDevelop;
        }

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull => null;

        public bool IsEnabled(LogLevel logLevel) => _isDevelop ? true : logLevel == LogLevel.Information;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            if (formatter != null)
                lock (_locker)
                    using (var sw = new StreamWriter(_fileName,true))
                        sw.WriteLine($"{DateTime.Now}:{logLevel}:{formatter(state, exception)}{Environment.NewLine}");
        }
    }
}
