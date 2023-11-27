namespace CreditRegistrationService.Logs
{
    public class FileLoggerProvider : ILoggerProvider
    {

        string _filePath;
        bool _isDevelop;

        public FileLoggerProvider(ConfigurationManager config, bool isDevelop)
        {
            _filePath = config.GetSection("Logging").GetValue<string>("FileName");
            _isDevelop = isDevelop;
        }
        public ILogger CreateLogger(string categoryName) => new FileLogger(_filePath, _isDevelop);

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
