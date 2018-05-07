using System.Diagnostics;
using System.Threading;

namespace Selenium.WebTest.Framework.Support.Common
{
    public class OsHelper
    {
        PerformanceCounter _cpuCounter;
        PerformanceCounter _ramCounter;

        public float GetCurrentCpuUsage()
        {
            _cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            _cpuCounter.NextValue();
            Thread.Sleep(1000);
            return _cpuCounter.NextValue();
        }

        public float GetAvailableRam()
        {
            _ramCounter = new PerformanceCounter("Memory", "Available MBytes");
            return _ramCounter.NextValue();
        }
    }
}
