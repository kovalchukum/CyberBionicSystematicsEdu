using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        private const long MaxMemoryBytes = 100000;

        static void Main(string[] args)
        {
            var memoryMonitor = new MemoryMonitor(MaxMemoryBytes);
            memoryMonitor.StartMonitoring();

            for (var i = 0; i <= 100; i++)
            {
                // Создаем экземпляры некого класса
                new DataGenerator();
            }

            Console.ReadKey();
            memoryMonitor.StartMonitoring();
        }
    }
}
