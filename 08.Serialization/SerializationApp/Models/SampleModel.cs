using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SerializationApp
{
    public class SampleModel
    {
        public string Version { get; set; } = "1.0";

        public int IntValue { get; set; } = 777;

        public DateTime DateTimeValue { get; set; } = DateTime.Now;
    }
}
