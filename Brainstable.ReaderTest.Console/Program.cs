using System;
using System.Collections.Generic;
using System.IO;
using Brainstable.ReaderTest;

namespace Brainstable.ReaderTest.Console
{
    class Program
    {
        private static string fileName = "data\\S2020_47";
        
        static void Main(string[] args)
        {
            List<VTest> list = VReader.Read(fileName);
            System.Console.ReadKey();
        }
    }
}