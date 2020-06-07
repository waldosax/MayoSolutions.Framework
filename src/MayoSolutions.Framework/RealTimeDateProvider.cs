using System;

namespace MayoSolutions.Framework
{
    public class RealTimeDateProvider : IDateTimeProvider
    {
        public DateTime Now => DateTime.Now;
        public DateTime UtcNow => DateTime.UtcNow;
    }
}