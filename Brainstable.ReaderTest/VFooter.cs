using System;
using System.Text.RegularExpressions;

namespace Brainstable.ReaderTest
{
    public class VFooter
    {
        private const string PATTERN = @"\b[E]\w+";
        
        /// <summary>
        /// Есть ли конец опыта
        /// </summary>
        public bool IsEndTrue => IsMatch(StringLine);
        /// <summary>
        /// Строка
        /// </summary>
        public string StringLine { get; set; }

        public override string ToString()
        {
            return StringLine;
        }

        /// <summary>
        /// Соответствие строки конца записи паттерну
        /// </summary>
        /// <param name="line">Строка конца записи</param>
        /// <returns>True - строка конца записи соответствует паттерну</returns>
        public static bool IsMatch(string line)
        {
            Regex regex = new Regex(PATTERN);
            return regex.IsMatch(line);
        }

        public static VFooter CreateFooter(string line)
        {
            if (line.Length == 0)
            {
                throw new Exception("");
            }
            
            if (!IsMatch(line))
            {
                throw new Exception("Regex");
            }

            VFooter vFooter = null;
            if (line.Trim() == "END")
            {
                vFooter = new VFooter();
                vFooter.StringLine = line;
            }

            return vFooter;
        }
    }
}