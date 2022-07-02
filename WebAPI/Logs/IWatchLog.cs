using System.Diagnostics;

namespace WebAPI.Logs
{
    public interface IWatchLog
    {
        Stopwatch watch { get; }
        long ElapsedMilliseconds { get; }
        bool IsRunning { get; }
        void Restart();
        void Stop();
    }
}
