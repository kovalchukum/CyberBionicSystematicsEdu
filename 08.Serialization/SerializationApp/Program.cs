using System;
using System.IO;
using System.Xml.Serialization;

//    Создайте класс, поддерживающий сериализацию.Выполните сериализацию объекта этого
//    класса в формате XML.Сначала используйте формат по умолчанию, а затем измените его
//    таким образом, чтобы значения полей сохранились в виде атрибутов элементов XML.
// +
//    Создайте новое приложение, в котором выполните десериализацию объекта из предыдущего
//    примера. Отобразите состояние объекта на экране.

namespace SerializationApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Try to sirialize SampleModel...");
            var sampleModel = new SampleModel();
            var serializer = new XmlSerializer(typeof(SampleModel));

            using (FileStream fs = new FileStream("SampleModel.xml", FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, sampleModel);
                Console.WriteLine($"SampleModel serialized in file: {fs.Name}");
            }
            Console.WriteLine("Done.");

            Console.WriteLine();
            Console.WriteLine(new string('-', 30));
            Console.WriteLine();


            Console.WriteLine("Now do some serialization in XML and make values as xml attributes...");
            var sampleAttrModel = new SampleAttrModel();
            var serializerAttr = new XmlSerializer(typeof(SampleAttrModel));
            using (FileStream fs = new FileStream("SampleAttrModel.xml", FileMode.OpenOrCreate))
            {
                serializerAttr.Serialize(fs, sampleAttrModel);
                Console.WriteLine($"SampleAttrModel serialized in file: {fs.Name}");
            }
            Console.WriteLine("Done.");

            Console.WriteLine();
            Console.WriteLine(new string('-', 30));
            Console.WriteLine();

            Console.WriteLine("Now try to desirialize SampleModel...");
            using (FileStream fs = new FileStream("SampleModel.xml", FileMode.Open))
            {
                var sm = (SampleModel)serializer.Deserialize(fs);
                Console.WriteLine($"Version = {sm.Version}, IntValue = {sm.IntValue}, DateTimeValue = {sm.DateTimeValue}");
            }
            Console.WriteLine("Done.");

            Console.ReadKey();
        }
    }
}
