using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MemoryMonitorApp
{
    public class MemoryMonitor
    {
        private const int SleepInterval = 1000;
        private readonly long _memoryMaxUseBytes;
        private readonly Thread _monitoringThead;
        private bool _isMonitoring = false;
        private readonly Predicate<bool> _onMaxMemory;

        private bool IsMemoryUsedByGc()
        {
            return (GC.GetTotalMemory(true) > _memoryMaxUseBytes);
        }

        private void GcMemoryMonitor()
        {
            while (_isMonitoring)
            {
                if (IsMemoryUsedByGc())
                {
                    // Если предикат вернул положительный результат - завершаем работу приложения
                    if (_onMaxMemory(true))
                    {
                        StopMonitoring();
                        System.Diagnostics.Process.GetCurrentProcess().Kill();
                    }
                }
                else
                {
                    Thread.Sleep(SleepInterval);
                }
            }
        }

        public MemoryMonitor(long memoryMaxUseBytes, Predicate<bool> onMaxMemory)
        {
            _memoryMaxUseBytes = memoryMaxUseBytes;
            _onMaxMemory = onMaxMemory;
            _monitoringThead = new Thread(new ThreadStart(GcMemoryMonitor));

        }

        public void StartMonitoring()
        {
            if (_monitoringThead != null)
            {
                _isMonitoring = true;
                _monitoringThead.Start();
            }
            else
            {
                Console.WriteLine("Can't start monitoring!");
            }
        }

        public void StopMonitoring()
        {
            if (_monitoringThead != null)
            {
                _isMonitoring = false;
            }
            else
            {
                Console.WriteLine("Can't stop monitoring!");
            }
        }
    }
}
