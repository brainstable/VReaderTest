using System;
using System.Text.RegularExpressions;

namespace Brainstable.ReaderTest
{
    public class Header
    {
        private const int COUNT_CHARS = 83;
        const string STR_HEADER = "00030130 11111 1040 0361 0000 05 003 1206 2010 3105 2010 0206 2010 1 1031 01 0001 0";
        const string PATTERN = "[0-9]{8} [1-9]{5} [0-9]{4} [0-9]{4} [0-9]{4} [0-9]{2} [0-9]{3} [0-9]{4} [0-9]{4} [0-9]{4} [0-9]{4} [0-9]{4} [0-9]{4} [1-2]{1} [0-9]{4} [0-9]{2} [0-9]{4} [0-1]{1}";
        
        /// <summary>
        /// ИД опыта (номер опыта в рамках одного центра и одной культуры уникален)
        /// </summary>
        public string Id => $"{NumberCenter}{Culture}{NumberTest2}";

        /// <summary>
        /// Идентификатор опыта (Центр-Место-Год-Культура-Номер)
        /// </summary>
        public string Identificator => $"{NumberCenter}{Local}{YearCreated}{Culture}{NumberTest2}";
        /// <summary>
        /// Место проведения опыта (код места - 8 цифр)
        /// </summary>
        public string Local { get; set; }   
        /// <summary>
        /// Спецификации опыта (код - 5 цифр)
        /// </summary>
        public string Specification { get; set; }
        /// <summary>
        /// Культура, по которой проводится опыт (код культуры - 4 цифры)
        /// </summary>
        public string Culture { get; set; }
        /// <summary>
        /// Групповой предшественник (код - 4 цифры)
        /// </summary>
        public string GroupPredecessor { get; set; }
        /// <summary>
        /// Номер опыта (4 цифры)
        /// </summary>
        public string NumberTest { get; set; }
        /// <summary>
        /// Количество показателей (2 цифры)
        /// </summary>
        public string CountParameters { get; set; }
        /// <summary>
        /// Количество сортов (3 цифры)
        /// </summary>
        public string CountVarieties { get; set; }
        /// <summary>
        /// Дата уборки урожая (4 цифры)
        /// </summary>
        public string DateHarvest { get; set; }
        /// <summary>
        /// Год уборки урожая (4 цифры)
        /// </summary>
        public string YearHarvest { get; set; }
        /// <summary>
        /// Дата закладки опыта (4 цифры)
        /// </summary>
        public string DateCreated { get; set; }
        /// <summary>
        /// Год закладки опыта (4 цифры)
        /// </summary>
        public string YearCreated { get; set; }
        /// <summary>
        /// Дата последней коррекции опыта (4 цифры)
        /// </summary>
        public string DateEdited { get; set; }
        /// <summary>
        /// Год последней коррекции опыта (4 цыфры)
        /// </summary>
        public string YearEdited { get; set; }
        /// <summary>
        /// Тип данных (1 цифра)
        /// </summary>
        public string TypeData { get; set; }
        /// <summary>
        /// Культурный предшественник (4 цифры)
        /// </summary>
        public string CulturePredecessor { get; set; }
        /// <summary>
        /// Номер центра (2 цифры)
        /// </summary>
        public string NumberCenter { get; set; }
        /// <summary>
        /// Номер опыта (2 цифры)
        /// </summary>
        public string NumberTest2 { get; set; }
        /// <summary>
        /// Признак качества опыта (0 - хороший, 1 - плохой; 1 цифра)
        /// </summary>
        public string QualityAttribute { get; set; }
        /// <summary>
        /// Строка заголовка
        /// </summary>
        public string StringHeader { get; set; }

        /// <summary>
        /// Соответствие строки заголовка паттерну
        /// </summary>
        /// <param name="strHeader">Строка заголовка</param>
        /// <returns>True - строка заголовка соответствует паттерну</returns>
        public static bool IsMatch(string strHeader)
        {
            Regex regex = new Regex(PATTERN);
            return regex.IsMatch(strHeader);
        }

        /// <summary>
        /// Создание Header из строки заголовка
        /// </summary>
        /// <param name="strHeader">Строка заголовка</param>
        /// <returns>Header</returns>
        /// <exception cref="Exception"></exception>
        public static Header CreateHeader(string strHeader)
        {
            if (strHeader.Length != COUNT_CHARS)
            {
                throw new Exception("");
            }
            
            if (!IsMatch(strHeader))
            {
                throw new Exception("Regex");
            }

            Header header = null;
            string[] arr = strHeader.Split(' ');
            if (arr.Length == 18)
            {
                header = new Header();
                header.StringHeader = strHeader;
                header.Local = arr[0];
                header.Specification = arr[1];
                header.Culture = arr[2];
                header.GroupPredecessor = arr[3];
                header.NumberTest = arr[4];
                header.CountParameters = arr[5];
                header.CountVarieties = arr[6];
                header.DateHarvest = arr[7];
                header.YearHarvest = arr[8];
                header.DateCreated = arr[9];
                header.YearCreated = arr[10];
                header.DateEdited = arr[11];
                header.YearCreated = arr[12];
                header.TypeData = arr[13];
                header.CulturePredecessor = arr[14];
                header.NumberCenter = arr[15];
                header.NumberTest2 = arr[16];
                header.QualityAttribute = arr[17];
            }
            return header;
        }
    }
}