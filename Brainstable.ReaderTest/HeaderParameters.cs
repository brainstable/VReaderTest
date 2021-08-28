using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Brainstable.ReaderTest
{
    public class HeaderParameters
    {
        private const string LINE = "           1 005 1 007 1 008 0 017 1 018 1 362 1 392 1 011";
        private const string PATTERN = "[ ]{11}[0-2]{1} [0-9]{3}";
        
        /// <summary>
        /// Список параметров
        /// </summary>
        public IList<SchemaParameter> SchemaParameters { get; set; }
        /// <summary>
        /// Количество параметров
        /// </summary>
        public int Count => SchemaParameters?.Count ?? 0;
        /// <summary>
        /// Строка заголовка параметров
        /// </summary>
        public string StringLine { get; set; }
        
        /// <summary>
        /// Соответствие строки заголовка параметров паттерну
        /// </summary>
        /// <param name="strHeader">Строка заголовка параметров</param>
        /// <returns>True - строка заголовка параметров соответствует паттерну</returns>
        public static bool IsMatch(string strHeader)
        {
            Regex regex = new Regex(PATTERN);
            return regex.IsMatch(strHeader);
        }

        public HeaderParameters()
        {
            SchemaParameters = new List<SchemaParameter>();
        }

        public static HeaderParameters CreateHeaderParameters(string strHeader)
        {
            if (strHeader.Length == 0)
            {
                throw new Exception("");
            }
            
            if (!IsMatch(strHeader))
            {
                throw new Exception("Regex");
            }

            string[] arr = strHeader.Trim().Split(' ');
            int countParameters = arr.Length / 2;
            string[,] pars = new string[2, countParameters];
            int n = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (i % 2 == 0)
                {
                    pars[0, n] = arr[i];
                }
                else
                {
                    pars[1, n++] = arr[i];
                }
            }

            HeaderParameters headerParameters = null;
            if (countParameters > 0)
            {
                headerParameters = new HeaderParameters();
                headerParameters.StringLine = strHeader;
                for (int i = 0; i < countParameters; i++)
                {
                    headerParameters.SchemaParameters.Add(new SchemaParameter
                    {
                        Power = pars[0, i],
                        ParameterId = pars[1, i]
                    });
                }
            }
            
            return headerParameters;
        }
    }
}