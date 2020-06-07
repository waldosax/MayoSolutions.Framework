using System;
using System.Threading.Tasks;

namespace MayoSolutions.Framework.Logging
{
    public class ConsoleLogEventSubscriber : ILogEventSubscriber
    {
        private static readonly object SyncObject = new object();
        private static bool? _canColorize;

        private static bool CanColorize
        {
            get
            {
                if (_canColorize.HasValue) return _canColorize.Value;
                lock (SyncObject)
                {
                    try
                    {
                        var c = Console.ForegroundColor;
                        _canColorize = true;
                    }
                    catch (Exception)
                    {
                        _canColorize = false;
                    }
                }

                return _canColorize.Value;
            }
        }

        public virtual Task Receive(LogEntry entry)
        {
            if (CanColorize)
            {
                lock (SyncObject)
                {
                    Console.ForegroundColor = GetConsoleColor(entry.Level);
                    Console.WriteLine(entry.Message);
                    Console.ResetColor();
                    return Task.CompletedTask;
                }
            }
            Console.WriteLine(entry.Message);
            return Task.CompletedTask;
        }

        protected virtual ConsoleColor GetConsoleColor(LogLevel level)
        {
            switch (level)
            {
                case LogLevel.Info: return ConsoleColor.Gray;
                case LogLevel.Debug: return ConsoleColor.DarkCyan;
                case LogLevel.Warning: return ConsoleColor.DarkYellow;
                case LogLevel.Error: return ConsoleColor.Red;
                case LogLevel.Exception: return ConsoleColor.Magenta;
            }
            return ConsoleColor.Gray;
        }
    }
}