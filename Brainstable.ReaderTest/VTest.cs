using System.Text;

namespace Brainstable.ReaderTest
{
    public class VTest
    {
        public VHeader VHeader { get; set; }
        public VHeaderParameters VHeaderParameters { get; set; }
        public VBody VBody { get; set; }
        public VNsr VNsr { get; set; }
        public VFooter VFooter { get; set; }
        public bool IsHeaderParameters { get; set; }
        public bool IsVNsr { get; set; }

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