using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Brainstable.ReaderVTest
{
    public class VNsr
    {
        private const string PATTERN = @"\b[H|Н]\w+";
        
        /// <summary>
        /// Список НСР
        /// </summary>
        public IList<string> Nsrs { get; set; }
        /// <summary>
        /// Строка
        /// </summary>
        public string StringLine { get; set; }

        public VNsr()
        {
            Nsrs = new List<string>();
        }

        public override string ToString()
        {
            return StringLine;
        }

        /// <summary>
        /// Соответствие строки НСР паттерну
        /// </summary>
        /// <param name="line">Строка НСР</param>
        /// <returns>True - строка НСР соответствует паттерну</returns>
        public static bool IsMatch(string line)
        {
            Regex regex = new Regex(PATTERN);
            return regex.IsMatch(line);
        }

        public static VNsr CreateVNsr(string line)
        {
            if (line.Length == 0)
            {
                throw new Exception("");
            }
            
            if (!IsMatch(line))
            {
                throw new Exception("Regex");
            }

            line = line.Substring(6).Trim();
            string[] arr = line.Split(' ');
            VNsr vNsr = null;
            if (arr.Length > 0)
            {
                vNsr = new VNsr();
                vNsr.StringLine = line;
                for (int i = 0; i < arr.Length; i++)
                {
                    vNsr.Nsrs.Add(arr[i]);
                }
            }
            
            return vNsr;
        }
    }
}