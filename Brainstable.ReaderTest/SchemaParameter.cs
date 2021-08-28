namespace Brainstable.ReaderTest
{
    /// <summary>
    /// Множитель - Код показателя
    /// </summary>
    public class SchemaParameter
    {
        /// <summary>
        /// Множитель - одноразрядное число, показывающее число десятичных знаков в значении показателя
        /// </summary>
        public string Power { get; set; }
        /// <summary>
        /// Код показателя
        /// </summary>
        public string ParameterId { get; set; }

        public override string ToString()
        {
            return ParameterId;
        }
    }
}