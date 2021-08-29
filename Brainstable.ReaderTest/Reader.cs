using System.Collections.Generic;
using System.IO;

namespace Brainstable.ReaderTest
{
    public class Reader
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
                if (Header.IsMatch(arr[i]))
                {
                    if (end)
                    {
                        start = true;
                        end = false;
                        vTest = new VTest();
                        vTest.Header = Header.CreateHeader(arr[i]);
                        vTest.VBody = new VBody();
                        continue;
                    }
                }

                if (HeaderParameters.IsMatch(arr[i]))
                {
                    vTest.HeaderParameters = HeaderParameters.CreateHeaderParameters(arr[i]);
                    continue;
                }

                if (VLine.IsMatch(arr[i]))
                {
                    vTest.VBody.VLines.Add(VLine.CreateVLine(arr[i]));
                    continue;
                }

                if (Footer.IsMatch(arr[i]))
                {
                    vTest.Footer = Footer.CreateFooter(arr[i]);
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