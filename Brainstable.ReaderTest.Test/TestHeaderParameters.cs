using NUnit.Framework;

namespace Brainstable.ReaderTest.Test
{
    public class TestHeaderParameters
    {
        private const string LINE = "           1 005 1 007 1 008 0 017 1 018 1 362 1 392 1 011";
        private HeaderParameters headerParameters;
        
        
        [SetUp]
        public void Setup()
        {
            headerParameters = HeaderParameters.CreateHeaderParameters(LINE);
        }

        [Test]
        public void TestCountParameters()
        {
            Assert.AreEqual(headerParameters.SchemaParameters.Count, 8);
        }
    }
}