using System;
using System.Text.RegularExpressions;

namespace Brainstable.ReaderTest
{
    public class Footer
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

        public static Footer CreateFooter(string line)
        {
            if (line.Length == 0)
            {
                throw new Exception("");
            }
            
            if (!IsMatch(line))
            {
                throw new Exception("Regex");
            }

            Footer footer = null;
            if (line.Trim() == "END")
            {
                footer = new Footer();
                footer.StringLine = line;
            }

            return footer;
        }
    }
}