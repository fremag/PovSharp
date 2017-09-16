using Microsoft.VisualStudio.TestTools.UnitTesting;
using PovSharp.Values;

namespace PovSharp.tests.Values
{

    [TestClass]
    public class NumberMSTests
    {
        [TestMethod]
        public void TestName()
        {
            var n = new PovNumber("x");
            Assert.AreEqual(n.Name, "x");
        }

        [TestMethod]
        public void TestValue()
        {
            var n = new PovNumber(5);
            Assert.IsNull(n.Name);
            Assert.AreEqual(n.Value, 5);
        }

        [TestMethod]
        public void TestClone()
        {
            var n = new PovNumber(5);
            var m = n.Clone() as PovNumber;
            Assert.IsNull(m.Name);
            Assert.AreEqual(m.Value, 5);
        }

        [TestMethod]
        public void TestDoubleOperator()
        {
            PovNumber n = 5;
            Assert.IsNull(n.Name);
            Assert.AreEqual(n.Value, 5);
        }

        [TestMethod]
        public void TestPovCode()
        {
            PovNumber n = 5;
            Assert.AreEqual(n.ToPovCode(), "5");
             n = 5.2;
            Assert.AreEqual(n.ToPovCode(), "5.2");
        }
    }
}
