using System.Collections.Generic;
using System.Text;

namespace Brainstable.ReaderTest
{
    public class VBody
    {
        public IList<VLine> VLines { get; set; }

        public string GetText()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var line in VLines)
            {
                sb.AppendLine(line.StringLine);
            }

            return sb.ToString();
        }

        public VBody()
        {
            VLines = new List<VLine>();
        }

        public override string ToString()
        {
            return GetText();
        }
    }
}