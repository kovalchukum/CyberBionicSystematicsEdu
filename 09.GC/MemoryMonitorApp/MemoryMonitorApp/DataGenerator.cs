using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryMonitorApp
{
    public class DataGenerator
    {
        public DataGenerator()
        {
            var someData = new object[1000];
        }

        public string guid = Guid.NewGuid().ToString();
    }
}
