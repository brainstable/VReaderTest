using System.Text;

namespace Brainstable.ReaderTest
{
    /// <summary>
    /// Текстово-табличное представление сортоопыта
    /// </summary>
    public class VTest
    {
        /// <summary>
        /// Идентификатор опыта
        /// </summary>
        public string Identificator => VHeader?.Identificator ?? "";
        /// <summary>
        /// Строка заголовка
        /// </summary>
        public VHeader VHeader { get; set; }
        /// <summary>
        /// Строка параметров
        /// </summary>
        public VHeaderParameters VHeaderParameters { get; set; }
        /// <summary>
        /// Текстовое представление сортов и значений их показателей
        /// </summary>
        public VBody VBody { get; set; }
        /// <summary>
        /// Строка НСР
        /// </summary>
        public VNsr VNsr { get; set; }
        /// <summary>
        /// Строка конца
        /// </summary>
        public VFooter VFooter { get; set; }
        /// <summary>
        /// Есть ли строка параметров
        /// </summary>
        public bool IsHeaderParameters { get; set; }
        /// <summary>
        /// Есть ли строка НСР
        /// </summary>
        public bool IsVNsr { get; set; }
        /// <summary>
        /// Успешно ли проведен сортоопыт
        /// </summary>
        public bool IsSucces => IsHeaderParameters & IsVNsr;

        public string GetText()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(VHeader.StringLine);
            if (IsHeaderParameters)
            {
                sb.AppendLine(VHeaderParameters.StringLine);
            }
            sb.AppendLine(VBody.GetText());
            if (IsVNsr)
            {
                sb.AppendLine(VNsr.StringLine);
            }

            sb.AppendLine(VFooter.StringLine);
            return sb.ToString();
        }

        public override string ToString()
        {
            return GetText();
        }
    }
}