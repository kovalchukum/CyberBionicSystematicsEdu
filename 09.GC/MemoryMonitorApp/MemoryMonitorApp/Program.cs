using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

// Создайте класс, который позволит выполнять мониторинг ресурсов, используемых программой.
// Используйте его в целях наблюдения за работой программы, а именно: пользователь может
// указать приемлемые уровни потребления ресурсов(памяти), а методы класса позволят выдать
// предупреждение, когда количество реально используемых ресурсов приблизиться к
// максимально допустимому уровню.
namespace MemoryMonitorApp
{
    class Program
    {
        // Задаем максимум использованной памяти в байтах
        private const long MaxMemoryBytes = 100000;

        static void Main(string[] args)
        {
            Console.WriteLine($"Application started. Max memory = {MaxMemoryBytes/1024} Kb. Generating some data");

            Predicate<bool> onMaxMemory = delegate(bool stopThread)
            {
                var usedMemory = GC.GetTotalMemory(true);
                Console.WriteLine($"The memory used by the application has reached the set limit! Current used memory = {usedMemory/1024}Kb \nStop the application? (y/n)");
                return (Console.ReadKey().Key == ConsoleKey.Y);               
            };

            var memoryMonitor = new MemoryMonitor(MaxMemoryBytes, onMaxMemory);
            memoryMonitor.StartMonitoring();

            var dataList = new List<string>();

            for (var i = 0; i <= 10000; i++)
            {
                // Делаем некую работу, что отжирает память
                dataList.Add(new DataGenerator().guid);
                Thread.Sleep(5);
            }

            Console.WriteLine(dataList.Count);
            Console.WriteLine("Application has successfully completed its work.\nPress any key to stop monitoring...");

            Console.ReadKey();
            memoryMonitor.StopMonitoring();
        }
    }
}
