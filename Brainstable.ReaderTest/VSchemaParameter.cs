namespace Brainstable.ReaderVTest
{
    /// <summary>
    /// Множитель - Код показателя
    /// </summary>
    public class VSchemaParameter
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