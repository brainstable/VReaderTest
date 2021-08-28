using System.Collections.Generic;

namespace Brainstable.ReaderTest
{
    public class VBody
    {
        public IList<VLine> VLines { get; set; }

        public VBody()
        {
            VLines = new List<VLine>();
        }
    }
}