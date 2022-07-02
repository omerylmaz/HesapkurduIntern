using System.Diagnostics;

namespace WebAPI.Logs
{
    public class WatchLog : IWatchLog
    {
        public WatchLog()
        {
            watch = new Stopwatch();
        }
        public Stopwatch watch { get; }

        public long ElapsedMilliseconds => watch.ElapsedMilliseconds;

        public bool IsRunning => watch.IsRunning;


        public void Restart()
        {
            watch.Restart();
        }

        public void Stop()
        {
            watch.Stop();
        }
    }
}
