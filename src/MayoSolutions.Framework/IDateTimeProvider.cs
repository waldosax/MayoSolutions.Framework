using System;
using System.Collections.Generic;
using System.Text;

namespace MayoSolutions.Framework
{
    public interface IDateTimeProvider
    {
        DateTime Now { get; }
        DateTime UtcNow { get; }
    }
}
