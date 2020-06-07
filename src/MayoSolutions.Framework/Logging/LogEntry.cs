using System;

namespace MayoSolutions.Framework.Logging
{
    public class LogEntry
    {
        public LogLevel Level { get; set; }
        public virtual DateTime LogDate { get; set; }
        public virtual string Message { get; set; }

    }
}