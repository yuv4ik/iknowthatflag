using System;
using System.Threading;
using System.Threading.Tasks;

namespace IKnowThatFlag.Services
{
    public class NaiveTimer
    {
        TimeSpan interval { get; }
        CancellationTokenSource cancellationTokenSource { get; }
        int ticks;

        public NaiveTimer(TimeSpan interval)
        {
            this.interval = interval;
            cancellationTokenSource = new CancellationTokenSource();
        }

        public void Start(Action<int> callback)
        {
            Task.Factory.StartNew(async () =>
            {
                ticks = 0;
                while (!cancellationTokenSource.IsCancellationRequested)
                {
                    await Task.Delay(interval, cancellationTokenSource.Token);
                    callback?.Invoke(++ticks);
                }
            }, cancellationTokenSource.Token);
        }

        public void Stop()
        {
            cancellationTokenSource.Cancel();
        }
    }
}
