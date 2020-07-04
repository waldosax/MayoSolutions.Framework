using System.Diagnostics;
using System.Threading.Tasks;

namespace MayoSolutions.Framework.Logging
{
    public class DebugLogEventSubscriber : ILogEventSubscriber
    {
        public virtual Task Receive(LogEntry entry)
        {
            Debug.WriteLine(entry.Message);
            return Task.CompletedTask;
        }

    }
}