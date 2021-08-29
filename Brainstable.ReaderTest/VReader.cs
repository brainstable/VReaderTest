using System.Collections.Generic;
using System.IO;

namespace Brainstable.ReaderTest
{
    public class VReader
    {
        public static List<VTest> Read(string fileName)
        {
            List<VTest> vTests = new List<VTest>();
            
            string[] arr = File.ReadAllLines(fileName);
            
            bool start = false;
            bool end = true;
            VTest vTest = null;
            for (int i = 0; i < arr.Length; i++)
            {
                if (VHeader.IsMatch(arr[i]))
                {
                    if (end)
                    {
                        start = true;
                        end = false;
                        vTest = new VTest();
                        vTest.VHeader = VHeader.CreateHeader(arr[i]);
                        vTest.VBody = new VBody();
                        continue;
                    }
                }

                if (VHeaderParameters.IsMatch(arr[i]))
                {
                    vTest.VHeaderParameters = VHeaderParameters.CreateHeaderParameters(arr[i]);
                    vTest.IsHeaderParameters = true;
                    continue;
                }

                if (VLine.IsMatch(arr[i]))
                {
                    vTest.VBody.VLines.Add(VLine.CreateVLine(arr[i]));
                    continue;
                }

                if (VNsr.IsMatch(arr[i]))
                {
                    vTest.VNsr = VNsr.CreateVNsr(arr[i]);
                    vTest.IsVNsr = true;
                    continue;
                }

                if (VFooter.IsMatch(arr[i]))
                {
                    vTest.VFooter = VFooter.CreateFooter(arr[i]);
                    vTests.Add(vTest);
                    start = false;
                    end = true;
                    continue;
                }
            }
            
            return vTests;
        }
    }
}