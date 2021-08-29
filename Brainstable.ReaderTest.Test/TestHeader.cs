using NUnit.Framework;

namespace Brainstable.ReaderTest.Test
{
    public class TestHeader
    {
        const string STR_HEADER = "00030130 11111 1040 0361 0000 05 003 1206 2010 3105 2010 0206 2010 1 1031 01 0001 0";
        private VHeader _vHeader;
        
        
        [SetUp]
        public void Setup()
        {
            _vHeader = VHeader.CreateHeader(STR_HEADER);
        }

        [Test]
        public void TestCountStringHeader()
        {
            Assert.AreEqual(_vHeader.StringLine.Length, 83);
        }

        [Test]
        public void TestIsMatch()
        {
            Assert.IsTrue(VHeader.IsMatch(STR_HEADER));
        }
    }
}