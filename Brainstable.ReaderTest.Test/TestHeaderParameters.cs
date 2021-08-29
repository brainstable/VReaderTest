using NUnit.Framework;

namespace Brainstable.ReaderVTest.Test
{
    public class TestHeaderParameters
    {
        private const string LINE = "           1 005 1 007 1 008 0 017 1 018 1 362 1 392 1 011";
        private VHeaderParameters _vHeaderParameters;
        
        
        [SetUp]
        public void Setup()
        {
            _vHeaderParameters = VHeaderParameters.CreateHeaderParameters(LINE);
        }

        [Test]
        public void TestCountParameters()
        {
            Assert.AreEqual(_vHeaderParameters.SchemaParameters.Count, 8);
        }
    }
}