using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Brainstable.ReaderVTest
{
    public class VLine
    {
        private const string PATTERN = "[1-9][0-9]{6} [0-9]{2}";
        
        /// <summary>
        /// Код сорта
        /// </summary>
        public string VarietyId { get; set; }
        /// <summary>
        /// Код группы, код незакладки, год гибели
        /// </summary>
        public string Group { get; set; }
        /// <summary>
        /// Параметры
        /// </summary>
        public IList<string> Parameters { get; set; }
        /// <summary>
        /// Количество параметров
        /// </summary>
        public int CountParameters => Parameters?.Count ?? 0;
        /// <summary>
        /// Строка
        /// </summary>
        public string StringLine { get; set; }

        public VLine()
        {
            Parameters = new List<string>();
        }

        public override string ToString()
        {
            return StringLine;
        }

        /// <summary>
        /// Соответствие строки заголовка параметров паттерну
        /// </summary>
        /// <param name="line">Строка заголовка параметров</param>
        /// <returns>True - строка заголовка параметров соответствует паттерну</returns>
        public static bool IsMatch(string line)
        {
            Regex regex = new Regex(PATTERN);
            return regex.IsMatch(line);
        }
        
        /// <summary>
        /// Создание экземпляра класса VLine
        /// </summary>
        /// <param name="line">Строка</param>
        /// <returns>VLine</returns>
        /// <exception cref="Exception"></exception>
        public static VLine CreateVLine(string line)
        {
            if (line.Length == 0)
            {
                throw new Exception("");
            }
            
            if (!IsMatch(line))
            {
                throw new Exception("Regex");
            }
            
            string[] arr = line.Trim().Split(' ');
            int countParameters = arr.Length - 2;
            
            VLine vLine = new VLine();
            vLine.StringLine = line;
            vLine.VarietyId = arr[0];
            vLine.Group = arr[1];
            int n = 2;

            for (int i = 2; i < arr.Length; i++)
            {
                vLine.Parameters.Add(arr[i]);
            }

            return vLine;
        }
    }
}