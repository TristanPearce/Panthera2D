using System;
using System.Diagnostics;
using System.Threading;

namespace Panthera2D
{
    public class Clock : IDisposable
    {


        private Thread _thread;

        private double _interval;

        public event Action Tick;

        /// <summary>
        /// Ticks per second
        /// </summary>
        public float Frequency => Stopwatch.Frequency;

        /// <summary>
        /// Clock is based a high performance timer
        /// </summary>
        public bool IsHighResolution => Stopwatch.IsHighResolution;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="interval">in seconds</param>
        public Clock(double interval)
        {
            _interval = interval;

            _thread = new Thread(ClockFunc);

            _thread.Name = "Colossus2D Clock Thread";

            _thread.IsBackground = true;

            _thread.Start();
        }

        private void ClockFunc()
        {
            try
            {
                long interval = (long)(_interval * 10_000_000);
                long prevTick = Stopwatch.GetTimestamp();
                long currentTick = Stopwatch.GetTimestamp();
                long elapsed = 0;
                long diff = 0;

                int timeoutMs = 0;

                while (true)
                {
                    currentTick = Stopwatch.GetTimestamp();
                    if (elapsed >= interval)
                    {
                        Tick?.Invoke();
                        elapsed -= interval;
                    }
                    diff = currentTick - prevTick;
                    elapsed += diff;
                    prevTick = currentTick;

                    timeoutMs = (int)((interval - elapsed) / 10_000_000);

                    Thread.Sleep(timeoutMs);
                }
            }
            catch (ThreadAbortException ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void Dispose()
        {
            if (!_thread.IsAlive)
            {
                _thread.Abort();
            }
        }
    }
}
