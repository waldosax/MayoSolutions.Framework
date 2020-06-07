using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MayoSolutions.Framework.Logging
{
    public class Logger : ILogger
    {
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IEnumerable<ILogEventSubscriber> _subscribers;

        public Logger(
            IDateTimeProvider dateTimeProvider,
            IEnumerable<ILogEventSubscriber> subscribers
        )
        {
            _dateTimeProvider = dateTimeProvider;
            _subscribers = subscribers;
        }

        public void LogDebug(string message)
        {
            var entry = Create(LogLevel.Debug, message);
            Publish(entry);
        }
        public void LogInfo(string message)
        {
            var entry = Create(LogLevel.Info, message);
            Publish(entry);
        }
        public void LogWarning(string message)
        {
            var entry = Create(LogLevel.Warning, message);
            Publish(entry);
        }
        public void LogError(string message)
        {
            var entry = Create(LogLevel.Error, message);
            Publish(entry);
        }
        public void LogException(Exception e)
        {
            string message = string.Concat(
                e.GetType().Name, ": ",
                e.Message, Environment.NewLine,
                e.StackTrace
            );
            var entry = Create(LogLevel.Exception, message);
            Publish(entry);
        }

        private LogEntry Create(LogLevel level, string message)
        {
            return new LogEntry
            {
                Level = level,
                Message = message,
                LogDate = _dateTimeProvider.Now
            };
        }

        private void Publish(LogEntry logEntry)
        {
            List<Task> tasks = new List<Task>();
            foreach (var subscriber in _subscribers)
            {
                tasks.Add(subscriber.Receive(logEntry));
            }

            Task.WaitAll(tasks.ToArray());
        }
    }
}