using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MemoryMonitorApp
{
    public class MemoryMonitor
    {
        private const int SleepInterval = 1000;
        private long _memoryMaxUseBytes;
        private Thread _monitoringThead;

        private bool IsMemoryUsedByGc()
        {
            return (GC.GetTotalMemory(true) > _memoryMaxUseBytes);
        }

        private void GcMemoryMonitor()
        {
            if (IsMemoryUsedByGc())
                Console.WriteLine("The memory used by the application has reached the set limit!");
            Thread.Sleep(SleepInterval);
        }

        public MemoryMonitor(long MemoryMaxUseBytes)
        {
            _memoryMaxUseBytes = MemoryMaxUseBytes;
            _monitoringThead = new Thread(new ThreadStart(GcMemoryMonitor));

        }

        public void StartMonitoring()
        {
            if (_monitoringThead != null)
                _monitoringThead.Start();
            else
                Console.WriteLine("Can't start monitoring!");
        }

        public void StopMonitoring()
        {
            if (_monitoringThead != null)
                _monitoringThead.Abort();
            else
                Console.WriteLine("Can't stop monitoring!");
        }
    }
}
