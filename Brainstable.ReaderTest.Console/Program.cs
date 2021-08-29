using System.Collections.Generic;
using System.IO;

namespace Brainstable.ReaderTest.Console
{
    class Program
    {
        private static string fileName = "data\\S2020_47";
        
        static void Main(string[] args)
        {
            //List<string> listId = new List<string>();
            
            List<VTest> list = VReader.ReadFast(fileName);

            //foreach (var vTest in list)
            //{
            //    listId.Add(vTest.Identificator);
            //}

            string dir = "data\\zona\\zona11";
            string[] files = Directory.GetFiles(dir);

            for (int i = 0; i < files.Length; i++)
            {
                list.AddRange(VReader.ReadFast(files[i]));
            }

            System.Console.ReadKey();
        }
    }
}