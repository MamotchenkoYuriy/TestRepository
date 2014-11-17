using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW_3.Implaments;
using HW_3.Interfaces;
using HW_3.SourseCode;


namespace HW_3
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            List<LibraryItem> collection = new List<LibraryItem>();
            for (int i = 0; i < 10; i++)
            {
                collection.Add(new Book() { Author = "",  Name = "Book", Year = 10, Id = 1 });
            }
            for (int i = 0; i < 10; i++)
            {
                collection.Add(new Journal() { Number = 10, Name = "Test", Year = 10, Id = 1 });
            }
            Serializer<List<LibraryItem>>.Serialize(collection, "./SerialiseFile.xml");

            //Serializer.Serialize(collection, "./SerialiseFile.xml");
            //Serializer.Serialization("./SerialiseFile.xml", collection);
            var collect = Serializer<List<LibraryItem>>.DeSerialize("./SerialiseFile.xml");
            //var collect = Serializer.Deserialization("./SerialiseFile.xml");
            foreach (var item in collect)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadKey();*/
            new InteractiveConsole().Start();
        }
    }
}
