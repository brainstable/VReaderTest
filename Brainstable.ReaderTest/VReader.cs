using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata;

namespace Brainstable.ReaderTest
{
    public static class VReader
    { 
        /// <summary>
        /// Чтение из файла
        /// </summary>
        /// <param name="fileName">Файл для чтения</param>
        /// <returns>Список сортоопытов</returns>
        public static List<VTest> Read(string fileName)
        {
            List<VTest> tests = new List<VTest>();
            
            string[] arr = File.ReadAllLines(fileName);
            
            bool end = true;
            VTest test = null;
            for (int i = 0; i < arr.Length; i++)
            {
                if (VHeader.IsMatch(arr[i]))
                {
                    if (end)
                    {
                        end = false;
                        test = new VTest();
                        test.VHeader = VHeader.CreateHeader(arr[i]);
                        test.VBody = new VBody();
                        continue;
                    }
                }

                if (VHeaderParameters.IsMatch(arr[i]))
                {
                    test.VHeaderParameters = VHeaderParameters.CreateHeaderParameters(arr[i]);
                    test.IsHeaderParameters = true;
                    continue;
                }

                if (VLine.IsMatch(arr[i]))
                {
                    test.VBody.VLines.Add(VLine.CreateVLine(arr[i]));
                    continue;
                }

                if (VNsr.IsMatch(arr[i]))
                {
                    test.VNsr = VNsr.CreateVNsr(arr[i]);
                    test.IsVNsr = true;
                    continue;
                }

                if (VFooter.IsMatch(arr[i]))
                {
                    test.VFooter = VFooter.CreateFooter(arr[i]);
                    tests.Add(test);
                    end = true;
                    continue;
                }
            }
            
            return tests;
        }

        /// <summary>
        /// Чтение с потока
        /// </summary>
        /// <param name="fileName">Файл для чтения</param>
        /// <returns>Список сортоопытов</returns>
        public static List<VTest> ReadFast(string fileName)
        {
            List<VTest> tests = new List<VTest>();
            StreamReader file = new StreamReader(fileName);
            try
            {
                string line;
                bool end = true;
                VTest test = null;
                while ((line = file.ReadLine()) != null)
                {
                    if (VHeader.IsMatch(line))
                    {
                        if (end)
                        {
                            end = false;
                            test = new VTest();
                            test.VHeader = VHeader.CreateHeader(line);
                            test.VBody = new VBody();
                            continue;
                        }
                    }

                    if (VHeaderParameters.IsMatch(line))
                    {
                        test.VHeaderParameters = VHeaderParameters.CreateHeaderParameters(line);
                        test.IsHeaderParameters = true;
                        continue;
                    }

                    if (VLine.IsMatch(line))
                    {
                        test.VBody.VLines.Add(VLine.CreateVLine(line));
                        continue;
                    }

                    if (VNsr.IsMatch(line))
                    {
                        test.VNsr = VNsr.CreateVNsr(line);
                        test.IsVNsr = true;
                        continue;
                    }

                    if (VFooter.IsMatch(line))
                    {
                        test.VFooter = VFooter.CreateFooter(line);
                        tests.Add(test);
                        end = true;
                        continue;
                    }
                }
            }
            catch (IOException ex)
            {
            }
            catch (Exception ex)
            {

            }
            finally
            {
                file.Close();
            }
            return tests;
        }
    }
}