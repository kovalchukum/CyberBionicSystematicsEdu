using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public struct BookStruct
        {
            [DefaultBindingProperty = 343]
            public int Price;
            public string Author;
        }

        static void Main(string[] args)
        {
        }
    }
}
