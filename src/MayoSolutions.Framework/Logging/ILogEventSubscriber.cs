using System.Threading.Tasks;

namespace MayoSolutions.Framework.Logging
{
    public interface ILogEventSubscriber
    {
        Task Receive(LogEntry entry);
    }
}