using System.Collections.Generic;

namespace Brainstable.ReaderTest.Console
{
    class Program
    {
        private static string fileName = "data\\S2020_47";
        
        static void Main(string[] args)
        {
            List<string> listId = new List<string>();
            
            List<VTest> list = VReader.Read(fileName);

            foreach (var vTest in list)
            {
                listId.Add(vTest.Identificator);
            }
            System.Console.ReadKey();
        }
    }
}