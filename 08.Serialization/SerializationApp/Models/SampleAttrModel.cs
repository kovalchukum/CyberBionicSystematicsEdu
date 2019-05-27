using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;


namespace SerializationApp
{
    [XmlRoot("SampleAttrModel", Namespace = "SampleAttrModel", IsNullable = false)]
    public class SampleAttrModel
    {
        [XmlAttribute]
        public string Version { get; set; } = "1.0";

        [XmlAttribute]
        public int IntValue { get; set; } = 777;

        [XmlAttribute]
        public DateTime DateTimeValue { get; set; } = DateTime.Now;
    }
}
