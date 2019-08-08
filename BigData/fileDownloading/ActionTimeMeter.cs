using System;
using System.Diagnostics;

namespace fileDownloading
{
    public class ActionTimeMeter
    {
        private int count = 0;
        private Stopwatch stopWatch = new Stopwatch();

        public ActionTimeMeter() { if (this.count == 0) stopWatch.Start(); }

        public void Begin() => this.count++;
        public String End()
        {
            this.count--;

            if (this.count == 0)
            {
                stopWatch.Stop();

                // Get the elapsed time as a TimeSpan value.
                TimeSpan ts = stopWatch.Elapsed;

                // Format and display the TimeSpan value.
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                                                    ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                return elapsedTime;
            }
            return null;
        }
    }
}
