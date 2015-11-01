using qPatterns.Core.Configuration;
using log4net;
using log4net.Config;

namespace qPatterns.Core.Logging
{
    public class Log4NetAdapter : ILogger 
    {
        private readonly log4net.ILog _log;

        public Log4NetAdapter()
        {
            XmlConfigurator.Configure();
            _log = LogManager.GetLogger(ApplicationSettingsFactory.GetApplicationSettings().LoggerName);
        }

        public void Log(string message)
        {
            _log.Info(message);
        }
    }
}
