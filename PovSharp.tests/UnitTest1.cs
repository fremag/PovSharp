
using NUnit.Framework;

namespace PovSharp.tests
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            Assert.That(1, Is.EqualTo(2-1));
        }
    }
}
